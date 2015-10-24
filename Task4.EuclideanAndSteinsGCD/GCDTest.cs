using System;
using NUnit.Framework;
using GCDEuclideanAndSteins;
using System.Collections.Generic;

namespace GCDEuclideanAndSteins.Test
{
    [TestFixture]
    public class GCDTest
    {
        public IEnumerable<TestCaseData> TestDatas
        {
            get
            {
                yield return new TestCaseData(1071, 462).Returns(21);
                yield return new TestCaseData(124, 0).Returns(124);
                yield return new TestCaseData(0, 0).Returns(0);
                yield return new TestCaseData(-4, 8).Returns(4);
            }
        }

        [Test, TestCaseSource(nameof(TestDatas))]
        public int EuclideanAlgorithmWithSpeedTime_TestWithIEnumerable(int a, int b)
        {
            long time;
            int actEvklidMethod = GCD.EuclideanAlgorithmWithSpeedTime(out time, a, b);
            return actEvklidMethod;
        }

        [TestCase(new int[] {1024, 74, 15}, Result = 1)]
        public int EuclideanAlgorit_TestWithArrayParams(int[] numbers)
        {
            long time;
            int actEvklidMethod = GCD.EuclideanAlgorithmWithSpeedTime(out time, numbers);
            return actEvklidMethod;
        }

        [Test, TestCaseSource(nameof(TestDatas))]
        public int SteinsAlgorithm_WithTwoParams(int a, int b)
        {
            int result = GCD.SteinsAlgorithm(a, b);
            return result;
        }

        [TestCase(new int[] {12, 24, 300, 144}, Result = 12)]
        public int SteinsAlgorithmWithSpeedTime_WithArrayParams(int[] numbers)
        {
            long time;

            int result = GCD.EuclideanAlgorithmWithSpeedTime(out time, numbers);

            return result;
        }
    }
}

