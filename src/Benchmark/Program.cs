using System;
using System.Globalization;
using System.Threading;

namespace Benchmark
{
    class Program
    {
        static void Main()
        {
            // Warmup
            SetCulture();
            var average = Benchmark.This(SetCulture);
            Console.WriteLine(average.Execute());

            // Warmup
            SetConditionalCulture();
            var average2 = Benchmark.This(SetConditionalCulture);
            Console.WriteLine(average2.Execute());
        }

        private const int cultureId = 2057;
        private const int cycles = 100000;

        public static void SetCulture()
        {
            for (var i = 0; i < cycles; i++)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureId);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureId);
            }
        }

        public static void SetConditionalCulture()
        {
            for (var i = 0; i < cycles; i++)
            {
                if (Thread.CurrentThread.CurrentCulture.LCID != cultureId)
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureId);

                if (Thread.CurrentThread.CurrentUICulture.LCID != cultureId)
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureId);
            }
        }
    }
}
