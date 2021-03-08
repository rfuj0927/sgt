using EikonDataAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGT_MRA
{
    public class EikonDataApiDataQuerier : IDataQuerier
    {
        private static String EIKON_DATE_PATTERN = "yyyy-MM-dd";
        private IEikon mEikon = null;
        private HashSet<String> USE_PRICECLOSE_RICS = new HashSet<string>();

        public EikonDataApiDataQuerier(String apiKey)
        {
            mEikon = Eikon.CreateDataAPI();
            mEikon.SetAppKey(apiKey);

            USE_PRICECLOSE_RICS.Add(".SPXT");
        }

        private Dictionary<DateTime, double> GetTimeSeries(DateTime fromDt, DateTime toDt, string ticker, string dtField, string dblField)
        {
            List<String> fields = new List<string> { dtField, dblField };
            Dictionary<String, String> eParams = GetEikonDtParams(fromDt, toDt);
            int retryCount = 0;
            
            var data = ExecuteQuery(ticker, fields, eParams, retryCount);
            
            return GetDateTimeToDoubleMap(data);
        }

        private Deedle.Frame<int,string> ExecuteQuery(string ticker, List<string> fields, Dictionary<string, string> eParams, int retryCount)
        {
            try
            {
                return mEikon.GetData(new List<String> { ticker }, fields, eParams);
            }
            catch (Exception ex)
            {
                if(retryCount >= 30)
                {
                    ex.Data.Add("UserMessage", "BadRequest error despite numerous retries");
                    throw ex;
                }
                if (ex.Message.StartsWith("BadRequest: Backend error. 400 Bad Request"))
                {
                    retryCount++;
                    Thread.Sleep(1000);
                    return ExecuteQuery(ticker, fields, eParams, retryCount);
                }

                MessageBox.Show(ex.Message, "Eikon API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        Dictionary<DateTime, double> IDataQuerier.GetClosePriceSeries(DateTime fromDt, DateTime toDt, string ticker)
        {
            // hack for annoying reuters bugs
            if (USE_PRICECLOSE_RICS.Contains(ticker))
            {
                return GetTimeSeries(fromDt, toDt, ticker, "TR.PriceClose.Date", "TR.PriceClose");
            }
            else if (ticker.EndsWith("="))
            {
                // FX
                return GetTimeSeries(fromDt, toDt, ticker, "TR.EUROPECLOSEBIDPRICE.Date", "TR.EUROPECLOSEBIDPRICE");
            }
            return GetTimeSeries(fromDt, toDt, ticker, "TR.CLOSEPRICE.Date", "TR.CLOSEPRICE");
        }

        Dictionary<DateTime, double> IDataQuerier.GetEtfDividendSeries(DateTime fromDt, DateTime toDt, string ticker)
        {
            return GetTimeSeries(fromDt, toDt, ticker, "TR.FundExDate.Date", "TR.FundDiv");
        }

        Dictionary<DateTime, double> IDataQuerier.GetStockDividendSeries(DateTime fromDt, DateTime toDt, string ticker)
        {
            return GetTimeSeries(fromDt, toDt, ticker, "TR.DivDate", "TR.DivUnadjustedNet");
        }

        Dictionary<DateTime, double> IDataQuerier.GetNavPriceSeries(DateTime fromDt, DateTime toDt, string ticker)
        {
            return GetTimeSeries(fromDt, toDt, ticker, "TR.FundNav.Date", "TR.FundNav");
        }

        string IDataQuerier.GetUnderlyingIndex(string ticker)
        {
            var data = mEikon.GetData(
                ticker,
                "TR.FundBenchmarkInstrumentRIC"
                );

            return data.GetColumn<String>("Benchmark Instrument RIC").Get(0);
            // return data.GetColumnAt<String>(1).Get(0);
        }

        public static string ToEikonDtStr(DateTime dt)
        {
            return dt.ToString(EIKON_DATE_PATTERN);
        }

        public static Dictionary<string, string> GetEikonDtParams(DateTime fromDt, DateTime toDt)
        {
            return new Dictionary<String, String> { { "SDate", ToEikonDtStr(fromDt) }, { "EDate", ToEikonDtStr(toDt) } };
        }

        private Dictionary<DateTime, double> GetDateTimeToDoubleMap(Deedle.Frame<int,String> data)
        {
            Dictionary<DateTime, double> d = new Dictionary<DateTime, double>();
            foreach (var r in data.Rows.ObservationsAll)
            {
                // expected instrument, date, field 
                try
                {
                    Object o1 = r.Value.Value.GetAt(1);
                    DateTime dt;
                    if(o1.GetType() == typeof(string))
                    {
                        dt = DateTime.Parse((string) o1);
                    }
                    else
                    {
                        dt = (DateTime) o1;
                    }
                    d.Add(dt, Convert.ToDouble(r.Value.Value.GetAt(2)));
                }catch(Exception ex)
                {
                    System.Console.Out.Write("TimeSeries data error: " + r.Value.ToString(), ex);
                }
            }
            return d;
        }
    }
}
