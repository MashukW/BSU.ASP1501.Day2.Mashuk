using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace GCDEuclideanAndSteins
{
    public class GCD
    {
        #region Euclidean Algorithm
        public static int EuclideanAlgorithm(int a, int b)
        {
            if (a < b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            int mod = 0;

            while (b != 0)
            {
                mod = a % b;
                a = b;
                b = mod;
            }

            return Math.Abs(a);
        }

        public static int EuclideanAlgorithm(params int[] numbers)
        {
            int gcd = EuclideanAlgorithm(numbers[0], numbers[1]);

            for (int i = 2; i < numbers.Length; i++)
            {
                gcd = EuclideanAlgorithm(numbers[i], gcd);
            }

            return Math.Abs(gcd);
        }

        public static int EuclideanAlgorithmWithSpeedTime(out long timeWork, int a, int b)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int result = EuclideanAlgorithm(a, b);
            watch.Stop();
            timeWork = watch.ElapsedTicks;
            return result;
        }

        public static int EuclideanAlgorithmWithSpeedTime(out long timeWork, params int[] numbers)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int result = EuclideanAlgorithm(numbers);
            watch.Stop();
            timeWork = watch.ElapsedTicks;
            return result;
        }
        #endregion

        #region SteinsAlgorithm
        public static int SteinsAlgorithm(int a, int b)
        {
            if (a < 0)
                return Math.Abs(a);
            if (b < 0)
                return Math.Abs(b);
            if (a == b)
                return a;

            if (a == 0)
                return b;
            if (b == 0)
                return a;

            if (a%2 == 0)
            {
                if (b%2 != 0)
                    return SteinsAlgorithm(a >> 1, b);
                else
                    return SteinsAlgorithm(a >> 1, b >> 1) << 1;
            }

            if (b%2 == 0)
                return SteinsAlgorithm(a, b >> 1);

            if (a > b)
                return SteinsAlgorithm((a - b) >> 1, b);

            return SteinsAlgorithm((b - a) >> 1, a);
        }

        private static int SteinsAlgorithm(params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentException("parametr is null");
            if (numbers.Length == 0)
                throw new ArgumentException("parametr is invalid");

            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                result = SteinsAlgorithm(result, numbers[i]);
            }

            return result;
        }

        public static int SteinsAlgorithmWithSpeedTime(out long time, int a, int b)
        {
            Stopwatch timeWork = new Stopwatch();
            timeWork.Start();
            int result = SteinsAlgorithm(a, b);
            timeWork.Stop();
            time = timeWork.ElapsedTicks;
            return result;
        }

        public static int SteinsAlgorithmWithSpeedTime(out long time, params int[] numbers)
        {
            Stopwatch timeWork = new Stopwatch();
            timeWork.Start();
            int result = SteinsAlgorithm(numbers);
            timeWork.Stop();
            time = timeWork.ElapsedTicks;
            return result;
        }
        #endregion
    }
}
