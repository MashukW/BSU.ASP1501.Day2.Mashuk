using System;
using System.Collections.Generic;
using System.Diagnostics;
using CustomerFormat;
using NUnit.Framework;

namespace CustomerFormat.Test
{
    [TestFixture]
    public class CustomerTest
    {
        public IEnumerable<TestCaseData> TestDatas
        {
            get
            {
                yield return new TestCaseData("NRC").Returns(@"Customer record: Jeffrey Richter, 1,000,000.00 , +1 (425) 555-0100");
                yield return new TestCaseData("CP").Returns(@"Customer record: +1 (425) 555-0100");
                yield return new TestCaseData("NR").Returns(@"Customer record: Jeffrey Richter, 1,000,000.00 ");
                yield return new TestCaseData("N").Returns(@"Customer record: Jeffrey Richter");
                yield return new TestCaseData("R").Returns(@"Customer record: 1000000");
                yield return new TestCaseData("NrC").Returns(@"Customer record: Jeffrey Richter, 1,000,000.00 , +1 (425) 555-0100");
                yield return new TestCaseData("r").Returns(@"Customer record: 1000000");
                yield return new TestCaseData("NBVC").Throws(typeof(FormatException));
            }
        }

        [Test, TestCaseSource(nameof(TestDatas))]
        public string ToString_WithOthersFormatString(string format)
        {
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            Stopwatch watch = new Stopwatch();

            string actResultString = customer.ToString(format);
            
            return actResultString;
        }
    }
}
