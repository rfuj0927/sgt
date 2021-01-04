using System;
using System.Collections.Generic;
using System.Linq;
using static SGT_Tool.SingleAsxAuctionSimulator;

namespace SGT_Tool.AsxAuctionSimulator
{
    public class AsxAuctionMatchCalculator
    {
        public static AuctionMatchResult Calc(List<DisplayOrder> bids, List<DisplayOrder> asks)
        {
            AuctionMatchResult result = new AuctionMatchResult();

            Double[] candidatePriceSet = bids.Select(x => x.Px).Union(asks.Select(x => x.Px)).Distinct().OrderBy(y=> y).ToArray();
            int[] cumBuyQty = new int[candidatePriceSet.Length];
            int[] cumSellQty = new int[candidatePriceSet.Length];
            int[] maxExecVol = new int[candidatePriceSet.Length];
            int[] minimumSurplus = new int[candidatePriceSet.Length];

            int i = 0;
            int maxVol = 0;
            List<int> maxExecVolCandidateIndices = new List<int>();
            foreach (Double px in candidatePriceSet)
            {
                cumBuyQty[i] = bids.Where(x => x.Px >= px).Sum(x => x.Qty);
                cumSellQty[i] = asks.Where(x => x.Px <= px).Sum(x => x.Qty);
                maxExecVol[i] = Math.Min(cumBuyQty[i], cumSellQty[i]);
                minimumSurplus[i] = cumBuyQty[i] - cumSellQty[i];

                if (maxExecVol[i] == maxVol)
                {
                    maxExecVolCandidateIndices.Add(i);
                }
                else if (maxExecVol[i] > maxVol)
                {
                    maxExecVolCandidateIndices.Clear();
                    maxExecVolCandidateIndices.Add(i);
                    maxVol = maxExecVol[i];
                }
               
                i++;
            }

            if (maxExecVolCandidateIndices.Count() <= 0)
            {
                // no overlaps
                return result;
            }

            if (maxExecVolCandidateIndices.Count() == 1)
            {
                // meq is enough
                result.IEP = candidatePriceSet[maxExecVolCandidateIndices.First()];
                result.IEV = maxExecVol[maxExecVolCandidateIndices.First()];
                return result;
            }

            int minSurplus = int.MaxValue;
            List<int> minSurplusCandidateIndices = new List<int>();
            foreach (int c in maxExecVolCandidateIndices)
            {
                if (Math.Abs(minimumSurplus[c]) == minSurplus)
                {
                    minSurplusCandidateIndices.Add(c);
                }
                else if (Math.Abs(minimumSurplus[c]) < minSurplus)
                {
                    minSurplusCandidateIndices.Clear();
                    minSurplusCandidateIndices.Add(c);
                    minSurplus = minimumSurplus[c];
                }
            }

            int pressure = 0;
            foreach (int c in minSurplusCandidateIndices)
            {
                pressure += Math.Sign(minimumSurplus[c]);
            }

            if (pressure > 0)
            {
                result.IEP = candidatePriceSet[minSurplusCandidateIndices.Last()];
                result.IEV = maxExecVol[minSurplusCandidateIndices.Last()];
                return result;
            }

            // we either solved with min surplus already, or we just use the sell pressure as we dont have a concept of previous close price.
            result.IEP = candidatePriceSet[minSurplusCandidateIndices.First()];
            result.IEV = maxExecVol[minSurplusCandidateIndices.First()];
            return result;
        }
    }
}
