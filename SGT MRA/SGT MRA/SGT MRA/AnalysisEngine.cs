using Accord.Math.Optimization.Losses;
using Accord.Statistics.Models.Regression.Linear;
using SGTUtils.SgtMathUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGT_MRA
{
    public class AnalysisEngine
    {
        public event Action<string> ProgressChanged;

        private MraParams mMraParams;
        private IDataQuerier mDataQuerier;
        private BindingList<RegressionResult> mRegressionResults = new BindingList<RegressionResult>();

        public AnalysisEngine(MraParams p, IDataQuerier q)
        {
            this.mMraParams = p;
            this.mDataQuerier = q;
        }

        public void RunLinearRegressions()
        {
            mRegressionResults.Clear();
            HashSet<DateTime> intersectDates;

            // fetch y param
            OnProgressChanged($"Fetching {mMraParams.yVariable.ticker} time series");
            mMraParams.yVariable.priceReturnSeries = GetTimeSeries(mMraParams.yVariable);
            intersectDates = mMraParams.yVariable.priceReturnSeries.Keys.ToHashSet();

            // fetch x params
            foreach (VariablePair vp in mMraParams.xVariables)
            {
                OnProgressChanged($"Fetching {vp.ticker} time series");
                vp.priceReturnSeries = GetTimeSeries(vp);

                intersectDates.IntersectWith(vp.priceReturnSeries.Keys);
            }

            OnProgressChanged($"Reformatting data");
            List<DateTime> dts = intersectDates.OrderBy(x => x.Ticks).ToList();

            double[] yVal = new double[dts.Count - 1];
            string[] xVars = mMraParams.xVariables.Select(x => x.ticker).ToArray();
            double[][] xVals = new double[dts.Count - 1][];

            PopulateArrayReturnSeries(dts, yVal, xVars, xVals);

            OnProgressChanged($"Performing Unhedged model");
            mRegressionResults.Add(PerformUnhedged(yVal));

            for (int k = 1; k <= xVars.Length; k++)
            {
                OnProgressChanged($"Performing Regressions for param count: " + k);
                mRegressionResults.Add(PerformMinimumSEOlsForK(yVal, xVars, xVals, k));
            }

            OnProgressChanged($"Completed");
        }

        private RegressionResult PerformUnhedged(double[] yVal)
        {
            RegressionResult r = new RegressionResult();          
            double average = yVal.Average();
            r.Mean = average;

            double sumOfSquaresOfDifferences = yVal.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / yVal.Length);

            r.ModelType = "UNHEDGED";
            r.StandardError = sd;
            r.xVarCount = 0;
            r.SamplesCount = yVal.Length;

            return r;
        }

        public BindingList<RegressionResult> GetResults(){
            return mRegressionResults;
        }

        private static RegressionResult PerformMinimumSEOlsForK(double[] yVal, string[] xVars, double[][] xVals, int k)
        {
            List<RegressionResult> regressionResults = new List<RegressionResult>();
            
            // for n=2
            // k=1, 2 elements of 1
            // k=2, 1 element of 2
            int[] indices = Enumerable.Range(0, xVars.Length).ToArray();
            var vars = SgtMathUtils.GetCombinations(indices, k);
            
            foreach (IEnumerable<int> i in vars)
            {
                string[] xxVars = new string[i.Count()];
                double[][] xxVals = new double[xVals.Length][];

                for (int f = 0; f < xVals.Length; f++)
                {
                    xxVals[f] = new double[xxVars.Length];
                }

                int count = 0;
                foreach (int j in i)
                {
                    xxVars[count] = xVars[j];
                 
                    for (int f = 0; f < xVals.Length; f++)
                    {
                        xxVals[f][count] = xVals[f][j];
                    }
                    count++;
                }            
                
                regressionResults.Add(PerformOls(yVal, xxVars, xxVals));
            }
            
            return regressionResults.OrderBy(x => x.StandardError).First();
        }

        private static RegressionResult PerformOls(double[] yVal, string[] xVars, double[][] xVals)
        {
            var ols = new OrdinaryLeastSquares()
            {
                // intercept should represent the return if no impact from inputs. (mean daily return)
                UseIntercept = false
            };

            MultipleLinearRegression regression = ols.Learn(xVals, yVal);
            double[] predicted = regression.Transform(xVals);

            RegressionResult r = new RegressionResult();
            r.ModelType = "OLS";
            r.StandardError = regression.GetStandardError(xVals, yVal);
            r.RSquared = new RSquaredLoss(xVals.Length, yVal).Loss(predicted);
            r.Betas = string.Join(";", regression.Weights.Select(x=>Math.Round(x, 4)).ToList());
            r.xVars = string.Join(";", xVars);
            r.xVarCount = regression.NumberOfInputs;
            r.SamplesCount = yVal.Length;
            r.Mean = regression.Intercept;

            return r;
        }

        private void PopulateArrayReturnSeries(List<DateTime> dts, double[] yVals, string[] xVars, double[][] xVals)
        {
            int i;
            for (i = 0; i < dts.Count - 1; i++)
            {
                xVals[i] = new double[xVars.Length];
            }

            i = 0;
            DateTime? priorDt = null;
            foreach (DateTime dt in dts)
            {
                if (priorDt != null)
                {
                    if (mMraParams.returnType == ReturnType.Simple)
                    {
                        yVals[i] = mMraParams.yVariable.priceReturnSeries[dt] / mMraParams.yVariable.priceReturnSeries[(DateTime)priorDt] - 1;
                        int j = 0;
                        foreach (VariablePair vp in mMraParams.xVariables)
                        {
                            xVals[i][j] = vp.priceReturnSeries[dt] / vp.priceReturnSeries[(DateTime)priorDt] - 1;
                            j++;
                        }
                    }
                    else if (mMraParams.returnType == ReturnType.Log)
                    {
                        yVals[i] = Math.Log(mMraParams.yVariable.priceReturnSeries[dt] / mMraParams.yVariable.priceReturnSeries[(DateTime)priorDt]);
                        int j = 0;
                        foreach (VariablePair vp in mMraParams.xVariables)
                        {
                            xVals[i][j] = Math.Log(vp.priceReturnSeries[dt] / vp.priceReturnSeries[(DateTime)priorDt]);
                            j++;
                        }
                    }

                    i++;
                }

                priorDt = dt;
            }
        }

        private Dictionary<DateTime, double> GetTimeSeries(VariablePair vp)
        {
            Dictionary<DateTime, double> series;

            switch (vp.seriesType)
            {
                case SeriesType.Price:

                    series = mDataQuerier.GetClosePriceSeries(mMraParams.fromDt, mMraParams.toDt, vp.ticker);
                    break;

                case SeriesType.NavTr:
                    {
                        series = mDataQuerier.GetNavPriceSeries(mMraParams.fromDt, mMraParams.toDt, vp.ticker);
                        Dictionary<DateTime, double> divSeries = mDataQuerier.GetEtfDividendSeries(mMraParams.fromDt, mMraParams.toDt, vp.ticker);
                        AddCumulativeDivsToTimeSeries(series, divSeries);
                        break;
                    }

                case SeriesType.PriceTr:
                    {
                        series = mDataQuerier.GetClosePriceSeries(mMraParams.fromDt, mMraParams.toDt, vp.ticker);
                        Dictionary<DateTime, double> divSeries = mDataQuerier.GetStockDividendSeries(mMraParams.fromDt, mMraParams.toDt, vp.ticker);
                        AddCumulativeDivsToTimeSeries(series, divSeries);
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

        private static void AddCumulativeDivsToTimeSeries(Dictionary<DateTime, double> series, Dictionary<DateTime, double> divSeries)
        {
            List<DateTime> dtKeys = new List<DateTime>(series.Keys);

            foreach (DateTime dt in dtKeys)
            {
                double cumDiv = divSeries.Where(k => k.Key <= dt).Select(k => k.Value).Sum();
                series[dt] = series[dt] + cumDiv;
            }
        }

        private void OnProgressChanged(string progress)
        {
            var eh = ProgressChanged;
            if(eh != null)
            {
                eh(progress);
            }
        }
    }
}
