using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGT_MRA
{
    public interface IDataQuerier
    {
        Dictionary<DateTime, double> GetClosePriceSeries(DateTime fromDt, DateTime toDt, String ticker);
        Dictionary<DateTime, double> GetEtfDividendSeries(DateTime fromDt, DateTime toDt, String ticker);
        Dictionary<DateTime, double> GetStockDividendSeries(DateTime fromDt, DateTime toDt, String ticker);
        Dictionary<DateTime, double> GetNavPriceSeries(DateTime fromDt, DateTime toDt, String ticker);
        String GetUnderlyingIndex(String ticker);
    }
}
