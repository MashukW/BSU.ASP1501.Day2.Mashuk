using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexFormatProviderIntegers
{
    public class HexFormatProvider : IFormatProvider, ICustomFormatter
    {
        private static readonly string[] unitBase = new string[]
        {
            "0", "1", "2", "3", "4", "5", "6", "7",
            "8", "9", "A", "B", "C", "D", "E", "F"
        };
        private IFormatProvider parentProvider;

        public HexFormatProvider() : this(CultureInfo.CurrentCulture)
        {
        }
        public HexFormatProvider(IFormatProvider provider)
        {
            parentProvider = provider;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string uformat = format.ToUpper(CultureInfo.InvariantCulture);
            if (arg == null || uformat != "HEX")
                return string.Format(parentProvider, "{0:" + format + "}", arg);

            if (arg.GetType() != typeof(int) && arg.GetType() != typeof(long))
                return string.Format(parentProvider, "{0:" + format + "}", arg);

            StringBuilder resultStr = new StringBuilder();

            long number = Convert.ToInt64(arg);
            bool minuse = false;
            if (number < 0)
            {
                number = Math.Abs(number);
                minuse = true;
            }

            do
            {
                int symbol = (int)(number % 16);
                resultStr.Insert(0, unitBase[symbol]);
                number /= 16;
            } while (number > 0);

            if (minuse)
                resultStr.Insert(0, "-");

            return "0x" + resultStr;
        }
    }
}
