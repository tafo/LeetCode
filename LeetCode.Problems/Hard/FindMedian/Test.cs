using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Hard.FindMedian
{
    public class Test
    {
        private readonly ITestOutputHelper _outputHelper;

        public Test(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Check()
        {
            var timer = Stopwatch.StartNew();
            var solution = new MedianFinder();
            timer.Start();
            solution.AddNum(1);
            solution.AddNum(2);
            solution.FindMedian().Should().Be(1.5);
            solution.AddNum(3);
            solution.FindMedian().Should().Be(2);
            timer.Stop();
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }
    }
}