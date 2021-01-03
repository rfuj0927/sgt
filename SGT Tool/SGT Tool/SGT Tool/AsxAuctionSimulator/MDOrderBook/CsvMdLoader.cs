using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGT_Tool.AsxAuctionSimulator.MDOrderBook
{
    public class CsvMdLoader : IMdLoader
    {

        public Dictionary<string, Orderbook> mSymbolToOrderbook = new Dictionary<string, Orderbook>();

        public CsvMdLoader(string csvFile)
        {
            LoadOrderbooks(csvFile);
        }

        private void LoadOrderbooks(string csvFile)
        {
            mSymbolToOrderbook.Clear();

            using (var reader = new StreamReader(csvFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = true;
                var records = csv.GetRecords<dynamic>();

                foreach (dynamic record in records)
                {
                    MdOrder mdOrder = MdOrder.FromMdLine(record);
                    if (!mSymbolToOrderbook.ContainsKey(mdOrder.Symbol))
                    {
                        mSymbolToOrderbook[mdOrder.Symbol] = new Orderbook();
                    }

                    if (mdOrder.Side == 'B')
                    {
                        mSymbolToOrderbook[mdOrder.Symbol].AddBid(mdOrder);
                    }
                    else if (mdOrder.Side == 'A')
                    {
                        mSymbolToOrderbook[mdOrder.Symbol].AddAsk(mdOrder);
                    }
                }
            }
        }
        Dictionary<string, Orderbook> IMdLoader.GetOrderbooks()
        {
            return mSymbolToOrderbook;
        }
    }
}
