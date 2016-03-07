using System;
using System.Diagnostics;

namespace Benchmark
{
    public sealed class Benchmark
    {
        private readonly Action _action;

        private Benchmark(Action action) { _action = action; }

        public static Benchmark This(Action action)
        {
            return new Benchmark(action);
        }

        public long Execute()
        {
            var watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            _action();
            watch.Stop();
            return watch.ElapsedTicks;
        }
    }
}