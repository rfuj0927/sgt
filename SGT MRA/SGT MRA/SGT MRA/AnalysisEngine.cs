using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGT_MRA
{
    public class AnalysisEngine
    {
        private MraParams mMraParams;
        private IDataQuerier mDataQuerier;

        public AnalysisEngine(MraParams p, IDataQuerier q)
        {
            this.mMraParams = p;
            this.mDataQuerier = q;
        }

        public void Run()
        {
            HashSet<DateTime> intersectDates;

            // fetch y param
            mMraParams.yVariable.priceReturnSeries = GetTimeSeries(mMraParams.yVariable);
            intersectDates = mMraParams.yVariable.priceReturnSeries.Keys.ToHashSet();

            // fetch x params
            foreach(VariablePair vp in mMraParams.xVariables)
            {
                vp.priceReturnSeries = GetTimeSeries(vp);

                intersectDates.IntersectWith(mMraParams.yVariable.priceReturnSeries.Keys);
            }

            List<DateTime> dts = intersectDates.OrderBy(x => x.Ticks).ToList();

            
        }

        private Dictionary<DateTime, double> GetTimeSeries(VariablePair vp)
        {
            Dictionary<DateTime, double> series;

            switch (vp.seriesType)
            {
                case SeriesType.NavTr:
                    {
                        series = mDataQuerier.GetNavPriceSeries(mMraParams.fromDt, mMraParams.toDt, vp.ticker);
                        Dictionary<DateTime, double> divSeries = mDataQuerier.GetEtfDividendSeries(mMraParams.fromDt, mMraParams.toDt, vp.ticker);
                        foreach (KeyValuePair<DateTime, double> kvp in divSeries)
                        {
                            series[kvp.Key] = series[kvp.Key] + divSeries.Where(k => k.Key <= kvp.Key).Select(k => k.Value).Sum();
                        }
                        break;
                    }
                case SeriesType.Price:

                    series = mDataQuerier.GetClosePriceSeries(mMraParams.fromDt, mMraParams.toDt, vp.ticker);
                    break;

                case SeriesType.PriceTr:
                    {
                        series = mDataQuerier.GetClosePriceSeries(mMraParams.fromDt, mMraParams.toDt, vp.ticker);
                        Dictionary<DateTime, double> divSeries = mDataQuerier.GetStockDividendSeries(mMraParams.fromDt, mMraParams.toDt, vp.ticker);
                        foreach (KeyValuePair<DateTime, double> kvp in divSeries)
                        {
                            series[kvp.Key] = series[kvp.Key] + divSeries.Where(k => k.Key <= kvp.Key).Select(k => k.Value).Sum();
                        }
                        break;
                    }
                default:
                    throw new Exception("Unexpected Series Type: " + vp.seriesType + " ticker: " + vp.ticker);
            }

            if (series == null || series.Count <= 0)
            {
                throw new Exception("No data retrieved for series Type: " + vp.seriesType + " ticker: " + vp.ticker);
            }

            return series;
        }
    }
}
