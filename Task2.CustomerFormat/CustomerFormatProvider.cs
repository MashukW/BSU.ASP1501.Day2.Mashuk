using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFormat
{
    class CustomerFormatProvider : IFormatProvider, ICustomFormatter
    {
        private delegate string CustomerFormat(Customer customer);
        private IFormatProvider parentProvider;

        public CustomerFormatProvider()
            : this(CultureInfo.CurrentCulture)
        {
        }

        public CustomerFormatProvider(IFormatProvider provider)
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
            Customer customer = arg as Customer;
            if (customer == null)
                throw new ArgumentException(" parametr 'arg' is incorrect");
            if (format == null)
                throw new NullReferenceException("parametr 'format' is null");

            Dictionary<string, CustomerFormat> outputFormts = new Dictionary<string, CustomerFormat>()
            {
                {"WT", new CustomerFormat(FormatCustomerWithTab)},
                {"WNL", new CustomerFormat(FormatCustomerWithNewLine)},
                {"WSQ", new CustomerFormat(FormatCustomerWithSingleQuote)},
                {"WDQ", new CustomerFormat(FormatCustomerWithDoubleQuote)}
            };

            format = format.ToUpper();
            if (outputFormts.ContainsKey(format))
                return outputFormts[format](customer);

            return String.Format(parentProvider, "Name: {0} ContactPhone: {1} Revenue: {2}",
                customer.Name, customer.ContactPhone, customer.Revenue);
        }

        private string FormatCustomerWithTab(Customer customer)
        {
            return String.Format("Name: {0}\t ContactPhone: {1}\t Revenue: {2}\t",
                customer.Name, customer.ContactPhone, customer.Revenue);
        }

        private string FormatCustomerWithNewLine(Customer customer)
        {
            return String.Format("Name: {0}\n ContactPhone: {1}\n Revenue: {2}\n",
                customer.Name, customer.ContactPhone, customer.Revenue);
        }

        private string FormatCustomerWithSingleQuote(Customer customer)
        {
            return String.Format("Name: '{0}' ContactPhone: '{1}' Revenue: '{2}'",
                customer.Name, customer.ContactPhone, customer.Revenue);
        }

        private string FormatCustomerWithDoubleQuote(Customer customer)
        {
            return String.Format("Name: \"{0}\" ContactPhone: \"{1}\" Revenue: \"{2}\"",
                customer.Name, customer.ContactPhone, customer.Revenue);
        }
    }
}
