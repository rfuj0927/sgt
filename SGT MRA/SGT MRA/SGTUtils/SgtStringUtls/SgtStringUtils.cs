using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGTUtils;

namespace SGTUtils
{
    public static class SgtStringUtils
    {
        public static string DoubleArrayToRoundedDelimitedString(double[] d)
        {
            return DoubleArrayToRoundedDelimitedString(d, ";", 4);
        }

        public static string DoubleArrayToRoundedDelimitedString(double[] d, string delim, int dp)
        {
            return string.Join(delim, d.Select(x => SgtMathUtils.RoundToSignificantDigits(x, dp)).ToList());
        }
    }
}
