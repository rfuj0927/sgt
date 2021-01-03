using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGT_Tool.AsxAuctionSimulator.MDOrderBook
{
    public class Orderbook
    {
        private List<MdOrder> mBids = new List<MdOrder>();
        private List<MdOrder> mAsks = new List<MdOrder>();

        public void AddBid(MdOrder o)
        {
            mBids.Add(o);
        }

        public void AddAsk(MdOrder o)
        {
            mAsks.Add(o);
        }

        public List<MdOrder> Bids()
        {
            return mBids.OrderByDescending(x=>x.Px).ThenBy(x=>x.PrioritySeq).ToList();
        }

        public List<MdOrder> Asks()
        {
            return mAsks.OrderBy(x => x.Px).ThenBy(x => x.PrioritySeq).ToList();
        }
    }
}
