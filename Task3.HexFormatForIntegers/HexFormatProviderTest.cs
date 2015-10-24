using System;
using NUnit.Framework;
using System.Globalization;
using HexFormatProviderIntegers;

namespace HexFormatProviderIntegers.Test
{
    [TestFixture]
    public class HexFormatProviderTest
    {
        [TestCase("hex", 25, Result = "0x19")]
        [TestCase("HEX", 25, Result = "0x19")]
        [TestCase("HeX", 25, Result = "0x19")]
        [TestCase("tem", 25, Result = "tem")]
        [TestCase("C", 25, Result = "25,00 ₽")]
        public string GetFormat_DifferentInputParameterFormat(string format, object arg)
        {
            HexFormatProvider testHex = new HexFormatProvider();

            string actString = testHex.Format(format, arg, CultureInfo.CurrentCulture);

            return actString;
        }

        [TestCase("hex", 25, Result = "0x19")]
        [TestCase("hex", -25, Result = "0x-19")]
        [TestCase("hex", 0, Result = "0x0")]
        public string GetFormat_DifferentInputParameterObjInteger(string format, object arg)
        {
            HexFormatProvider testHex = new HexFormatProvider();

            string actString = testHex.Format(format, arg, CultureInfo.CurrentCulture);

            return actString;
        }

        [TestCase("hex", null, Result = "")]
        [TestCase("hex", 0.11, Result = "hex")]
        public string GetFormat_DifferentInputParameterObjDoubleAndNull(string format, object arg)
        {
            HexFormatProvider testHex = new HexFormatProvider();

            string actString = testHex.Format(format, arg, CultureInfo.CurrentCulture);

            return actString;
        }

        [TestCase("hex", "Vadim")]
        public void GetFormat_DifferentInputParameterObjString(string format, object arg)
        {
            HexFormatProvider testHex = new HexFormatProvider();

            string actString = testHex.Format(format, arg, CultureInfo.CurrentCulture);

            StringAssert.AreEqualIgnoringCase(string.Format(CultureInfo.CurrentCulture, "{0:" + format + "}", arg), actString);
        }
    }
}
