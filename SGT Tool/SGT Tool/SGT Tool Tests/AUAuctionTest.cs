using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGT_Tool.AsxAuctionSimulator;
using System.Collections.Generic;
using static SGT_Tool.SingleAsxAuctionSimulator;

namespace SGT_Tool_Tests
{
    [TestClass]
    public class AUAuctionTest
    {
        [TestMethod]
        public void BasicAuctionTestMethod()
        {
            List<DisplayOrder> bids = new List<DisplayOrder>();
            List<DisplayOrder> asks = new List<DisplayOrder>();

            bids.Add(new DisplayOrder(1, 100));
            bids.Add(new DisplayOrder(0.99, 500));

            asks.Add(new DisplayOrder(0.99, 500));
            asks.Add(new DisplayOrder(0.99, 500));

            AuctionMatchResult r = AsxAuctionMatchCalculator.Calc(bids, asks);
            Assert.AreEqual(0.99, r.IEP);
            Assert.AreEqual(600, r.IEV);
        }
    }
}
