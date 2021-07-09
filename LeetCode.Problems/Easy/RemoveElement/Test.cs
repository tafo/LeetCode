using System.Collections.Generic;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Easy.RemoveElement
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
        public void Check(int[] numbers, int val, int output, int[] expectedNumbers) {
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            var actualOutput = solution.RemoveElement(numbers, val);
            timer.Stop();

            Assert.Equal(output, actualOutput);

            for (var i = 0; i < actualOutput; i++)
            {
                Assert.Equal(expectedNumbers[i], numbers[i]);
            }

            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        [Theory]
        [MemberData(nameof(InputAndOutput))]
        public void CheckBest(int[] numbers, int val, int output, int[] expectedNumbers) {
            var solution = new SolutionBest();
            var timer = Stopwatch.StartNew();
            var actualOutput = solution.RemoveElement(numbers, val);
            timer.Stop();

            Assert.Equal(output, actualOutput);

            for (var i = 0; i < actualOutput; i++)
            {
                Assert.Equal(expectedNumbers[i], numbers[i]);
            }

            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                new[]{3, 2, 2, 3},
                3,
                2,
                new[] {2, 2}
            },
            new object[]
            {
                new[]{0, 1, 2, 2, 3, 0, 4, 2},
                2,
                5,
                new[] {0, 1, 3, 0, 4}
            },
        };
    }
}