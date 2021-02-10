using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace SGT_MRA
{
    public class CustomTickerHistoryDataQuerier : IDataQuerier
    {
        private Dictionary<string, Dictionary<DateTime, Double>> mTickerToClosePriceHistory = new Dictionary<string, Dictionary<DateTime, Double>> ();
        private Dictionary<string, Dictionary<DateTime, Double>> mTickerToDivHistory = new Dictionary<string, Dictionary<DateTime, Double>>();
        private String mFilePath;

        public CustomTickerHistoryDataQuerier(string filePath)
        {
            if(filePath == null)
            {
                return;
            }

            mFilePath = filePath;
            Init();
        }

        private void Init()
        {
            using (TextFieldParser csvParser = new TextFieldParser(mFilePath))
            {
                csvParser.SetDelimiters(new string[] { "," });

                // Skip the row with the column names
                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    string ticker = fields[0];
                    DateTime dt = DateTime.ParseExact(fields[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    double price = double.Parse(fields[2]); 
                    double div = double.Parse(fields[3]);

                    if (!mTickerToClosePriceHistory.ContainsKey(ticker))
                    {
                        mTickerToClosePriceHistory.Add(ticker, new Dictionary<DateTime, Double>());
                        mTickerToDivHistory.Add(ticker, new Dictionary<DateTime, Double>());
                    }
                    mTickerToClosePriceHistory[ticker][dt] = price;
                    mTickerToDivHistory[ticker][dt] = div;
                }
            }

            MessageBox.Show("Using override custom ticker history for: " + string.Join(",", mTickerToClosePriceHistory.Keys));
        }

        public Boolean HasTicker(string ticker)
        {
            return mTickerToClosePriceHistory.ContainsKey(ticker);
        }

        public Dictionary<DateTime, double> GetClosePriceSeries(DateTime fromDt, DateTime toDt, string ticker)
        {
            return mTickerToClosePriceHistory[ticker];
        }

        public Dictionary<DateTime, double> GetStockDividendSeries(DateTime fromDt, DateTime toDt, string ticker)
        {
            return mTickerToDivHistory[ticker];
        }

        public Dictionary<DateTime, double> GetEtfDividendSeries(DateTime fromDt, DateTime toDt, string ticker)
        {
            return GetStockDividendSeries(fromDt, toDt, ticker);
        }

        public Dictionary<DateTime, double> GetNavPriceSeries(DateTime fromDt, DateTime toDt, string ticker)
        {
            return GetClosePriceSeries(fromDt, toDt, ticker);
        }

        public string GetUnderlyingIndex(string ticker)
        {
            throw new NotImplementedException();
        }
    }
}
