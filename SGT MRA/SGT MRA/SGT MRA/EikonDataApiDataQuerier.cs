using EikonDataAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGT_MRA
{
    public class EikonDataApiDataQuerier : IDataQuerier
    {
        private static String EIKON_DATE_PATTERN = "yyyy-MM-dd";
        private IEikon mEikon = null;

        public EikonDataApiDataQuerier(String apiKey)
        {
            mEikon = Eikon.CreateDataAPI();
            mEikon.SetAppKey(apiKey);
        }

        private Dictionary<DateTime, double> GetTimeSeries(DateTime fromDt, DateTime toDt, string ticker, string dtField, string dblField)
        {
            List<String> fields = new List<string> { dtField, dblField };
            Dictionary<String, String> eParams = GetEikonDtParams(fromDt, toDt);
            var data = mEikon.GetData(new List<String> { ticker }, fields, eParams);
            return GetDateTimeToDoubleMap(data);
        }

        Dictionary<DateTime, double> IDataQuerier.GetClosePriceSeries(DateTime fromDt, DateTime toDt, string ticker)
        {
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
