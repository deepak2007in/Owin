using System;
using System.Threading.Tasks;

namespace TPL
{
    public static class ParallelData
    {
        public static void ForWithBreak()
        {
            Parallel.For(1, 40000, (value, loopState) =>
                {
                    if(value > 10)
                    {
                        loopState.Break();
                    }
                    Console.WriteLine(value: loopState.ShouldExitCurrentIteration ? loopState.LowestBreakIteration.Value : -1);
                });
        }
    }
}
