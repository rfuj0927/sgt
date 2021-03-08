using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGTUtils
{
    public static class SgtMathUtils
    {
        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
                elements.SelectMany((e, i) =>
                elements.Skip(i + 1).GetCombinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }

        /**
         * If large number scale to appropriate sig figs.
         * If small number truncate.
         */
        public static double RoundToSignificantDigits(double d, int digits)
        {
            if (d == 0)
                return 0;

            double scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1);
            if(scale <= digits)
            {
                return Math.Round(d, digits);
            }
            return scale * Math.Round(d / scale, digits);
        }
    }
}
