using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Util
{
    public class Util
    {
        public static double ToDouble(string cadena) {
            var c = System.Threading.Thread.CurrentThread.CurrentCulture;
            var s = c.NumberFormat.CurrencyDecimalSeparator;

            cadena = cadena.Replace(",", s);
            cadena = cadena.Replace(".", s);

            return Convert.ToDouble(cadena);
        }
    }
}
