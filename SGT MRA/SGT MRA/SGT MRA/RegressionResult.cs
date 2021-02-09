using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGT_MRA
{
    public class RegressionResult
    {
        public string ModelType { get; set; }
        public int xVarCount { get; set; }
        
        public string xVars { get; set; }
        
        public string Betas { get; set; }
        public double RSquared { get; set; }
        public double StandardError { get; set; }
        public double Mean { get; set; }
        public int SamplesCount { get; set; }
    }
}
