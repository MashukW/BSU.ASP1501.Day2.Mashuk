using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace CustomerFormat
{
    public class Customer : IFormattable
    {
        public string Name { get; private set; }
        public string ContactPhone { get; private set; }
        public decimal Revenue { get; private set; }

        public Customer(string name, string phone, decimal revenue)
        {
            Name = name;
            ContactPhone = phone;
            Revenue = revenue;
        }

        public override string ToString()
        {
            return ToString("N", CultureInfo.CurrentCulture); 
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
                throw new ArgumentException("parametr 'format' is null");

            format = format.ToUpperInvariant();

            switch (format)
            {
                case "NRC":
                    return string.Format(GetNeedFormat(), "Customer record: {0}, {1:C}, {2}",
                        Name, Revenue, ContactPhone);
                    
                case "CP":
                    return string.Format("Customer record: {0}", ContactPhone);
                    
                case "NR":
                    return string.Format(GetNeedFormat(), "Customer record: {0}, {1:C}", Name, Revenue);
                    
                case "N":
                    return string.Format("Customer record: {0}", Name);
                    
                case "R":
                    return string.Format("Customer record: {0}", Revenue);

                default:
                    throw new FormatException($"The {format} format string not support");
            }
        }

        private NumberFormatInfo GetNeedFormat()
        {
            NumberFormatInfo resInfo = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            resInfo.CurrencyDecimalSeparator = ".";
            resInfo.CurrencyDecimalDigits = 2;
            resInfo.CurrencySymbol = "";
            resInfo.CurrencyGroupSeparator = ",";

            return resInfo;
        }
    }
}
