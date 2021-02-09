using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGT_MRA
{
    public class MraParams
    {
        public DateTime fromDt;
        public DateTime toDt;
        public VariablePair yVariable;
        public HashSet<VariablePair> xVariables = new HashSet<VariablePair>();
        public ReturnType returnType = ReturnType.Simple;
    }

    public class VariablePair
    {
        public string ticker;
        public SeriesType seriesType;
        public Dictionary<DateTime, double> priceReturnSeries { get; set; }

        public VariablePair(string ticker, SeriesType seriesType)
        {
            this.ticker = ticker;
            this.seriesType = seriesType;
        }
    }
}
