using EikonDataAPI;
using SGTUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGT_MRA
{
    public class BbgDataApiDataQuerier : IDataQuerier
    {
        public BbgDataApiDataQuerier()
        {
        }

        public Dictionary<DateTime, double> GetClosePriceSeries(DateTime fromDt, DateTime toDt, string ticker)
        {
            if(ticker.ToUpper().EndsWith("INDEX") || ticker.ToUpper().EndsWith("INDEX"))
            {
                return FetchTrPriceSeries(fromDt, toDt, ticker, BbgStrings.FieldNames.TOT_RETURN_INDEX_NET_DVDS, false);
            }
            return FetchTrPriceSeries(fromDt, toDt, ticker, BbgStrings.FieldNames.PX_LAST, false);
        }

        public Dictionary<DateTime, double> GetNavPriceSeries(DateTime fromDt, DateTime toDt, string ticker)
        {
            return FetchTrPriceSeries(fromDt, toDt, ticker, BbgStrings.FieldNames.TOT_RETURN_INDEX_NET_DVDS, true);
        }

        private Dictionary<DateTime, double> FetchTrPriceSeries(DateTime fromDt, DateTime toDt, string ticker, string fieldName, bool useNavBase)
        {
            List<string> secs = new List<string>();
            List<string> fields = new List<string>();
            Dictionary<string, string> overrideParams = new Dictionary<string, string>();
            Dictionary<string, string> optionalParams = new Dictionary<string, string>();
            
            secs.Add(ticker);

            fields.Add(fieldName);

            if (fieldName.Equals(BbgStrings.FieldNames.TOT_RETURN_INDEX_NET_DVDS))
            {
                overrideParams["ETF_TR_BASE"] = useNavBase ? "2" : "1";
            }
                        
            optionalParams[BbgStrings.QueryParams.PERIODICITY_ADJUSTMENT] = "ACTUAL";
            optionalParams[BbgStrings.QueryParams.PERIODICITY_SELECTION] = "DAILY";
            
            SecurityToDateToFldNameToFldVal requestResult = new BbgSession().PerformRequest(fromDt, toDt, secs, fields, optionalParams, overrideParams);
            Dictionary<DateTime, double> priceSeries = new Dictionary<DateTime, double>();

            DateToFldNameToFldVal dateToFlds = requestResult[ticker];
            foreach (DateTime dt in dateToFlds.Keys)
            {
                priceSeries[dt] = dateToFlds[dt][fieldName];
            }

            return priceSeries;
        }

        public Dictionary<DateTime, double> GetEtfDividendSeries(DateTime fromDt, DateTime toDt, string ticker)
        {
            // use blank as not required as already embedded in TR series
            return new Dictionary<DateTime, double>();
        }

        public Dictionary<DateTime, double> GetStockDividendSeries(DateTime fromDt, DateTime toDt, string ticker)
        {
            // use blank as not required as already embedded in TR series
            return new Dictionary<DateTime, double>();
        }

        public string GetUnderlyingIndex(string ticker)
        {
            throw new NotImplementedException();
        }
    }
}
