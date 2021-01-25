using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Hard.FindMedianSortedArrays
{
    public class Test
    {
        private readonly ITestOutputHelper _outputHelper;

        public Test(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Theory]
        [MemberData(nameof(InputAndOutput))]
        public void Check(int[] number1, int[] number2, double expectedOutput)
        {
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            solution.FindMedianSortedArrays(number1, number2).Should().Be(expectedOutput);
            timer.Stop();
            _outputHelper.WriteLine($"{timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput()
        {
            return new List<object[]>
            {
                new object[] {new int[] { }, new[] {1}, 1.0},
                new object[] {new int[] { }, new[] {1, 2}, 1.5D},
                new object[] {new int[] { }, new[] {1, 2, 3, 4}, 2.5D},
                new object[] {new[] {1}, new[] {2, 3, 4}, 2.5D},
                new object[] {new[] {1}, new[] {2, 3, 4, 5}, 3.0D},
                new object[] {new[] {2, 3}, new[] {1}, 2.0D},
                new object[] {new[] {2, 3}, new[] {2, 3}, 2.5D},
            };
        }
    }
}