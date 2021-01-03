using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SGT_Tool.SingleAsxAuctionSimulator;

namespace SGT_Tool.AsxAuctionSimulator
{
    public class AsxAuctionMatchCalculator
    {
        public static AuctionMatchResult Calc(List<DisplayOrder> bids, List<DisplayOrder> asks)
        {
            AuctionMatchResult result = new AuctionMatchResult();

            Double[] candidatePriceSet = bids.Select(x => x.Px).Union(asks.Select(x => x.Px)).Distinct().ToArray();
            Double[] cumBuyQty = new double[candidatePriceSet.Length];
            Double[] cumSellQty = new double[candidatePriceSet.Length];
            Double[] maxExecVol = new double[candidatePriceSet.Length];
            Double[] minimumSurplus = new double[candidatePriceSet.Length];
            Double[] marketPressure = new double[candidatePriceSet.Length];

            int i = 0;
            
            foreach(Double px in candidatePriceSet)
            {
                cumBuyQty[i] = bids.Where(x => x.Px >= px).Sum(x => x.Qty);
                cumSellQty[i] = asks.Where(x => x.Px <= px).Sum(x => x.Qty);
                maxExecVol[i] = Math.Min(cumBuyQty[i], cumSellQty[i]);
                minimumSurplus[i] = cumBuyQty[i] - cumSellQty[i];
                i++;
            }

            if (maxExecVol.Sum() <= 0)
            {
                // no overlaps
                return result;
            }


            return result;
        }
    }
}
