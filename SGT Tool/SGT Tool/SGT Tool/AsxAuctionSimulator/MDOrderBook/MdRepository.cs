using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGT_Tool.AsxAuctionSimulator.MDOrderBook
{
    public class MdRepository
    {
        private IMdLoader mLoader;

        public MdRepository(IMdLoader loader)
        {
            mLoader = loader;
        }

        public List<String> GetSymbols()
        {
            return mLoader.GetOrderbooks().Keys.ToList();
        }

        public Orderbook GetOrderbook(string symbol)
        {
            return mLoader.GetOrderbooks()[symbol];
        }
    }
}
