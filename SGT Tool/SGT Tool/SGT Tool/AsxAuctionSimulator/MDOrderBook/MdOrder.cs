using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SGT_Tool.AsxAuctionSimulator.MDOrderBook.CsvMdLoader;

namespace SGT_Tool.AsxAuctionSimulator.MDOrderBook
{
    public class MdOrder
    {
        public string Symbol;
        public char Side;
        public double Px;
        public int Qty;
        public int PrioritySeq;
        
        public static MdOrder FromMdLine(dynamic line)
        {
            MdOrder order = new MdOrder();
            order.Symbol = line.Stock;
            order.Side = line.Side[0];
            order.Px = double.Parse(line.Px);
            order.Qty = int.Parse(line.Qty);
            order.PrioritySeq = int.Parse(line.PrioritySeq);

            return order;
        }
    }
}
