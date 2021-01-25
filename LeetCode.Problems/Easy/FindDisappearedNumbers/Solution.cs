using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Easy.FindDisappearedNumbers
{
    public class Solution
    {
        public IList<int> Run(int[] nums)
        {
            var set = new HashSet<int>(Enumerable.Range(1, nums.Length));
            foreach (var num in nums)
            {
                set.Remove(num);
            }
            return set.ToList();
        }
    }

    /// <summary>
    /// ToDo: Add ToList feature. 
    /// </summary>
    public class TheHashSet
    {
        public class Number
        {
            public byte Digit;
            public bool IsLastDigit;
            public Number[] NextDigits;
            public Number(byte digit = 10)
            {
                Digit = digit;
            }

            public void Set(int value)
            {
                var digit = (byte)(value % 10);
                NextDigits ??= new Number[10];
                NextDigits[digit] ??= new Number(digit);
                var number = NextDigits[digit];
                if (value < 10)
                {
                    number.IsLastDigit = true;
                }
                else
                {
                    number.Set(value / 10);
                }
            }
        }

        public Number Root;

        public TheHashSet()
        {
            Root = new Number();
        }

        public void Add(int key)
        {
            Root.Set(key);
        }

        public void Remove(int key)
        {
            var number = Root;
            do
            {
                if (number.NextDigits == null) return;
                var digit = key % 10;
                number = number.NextDigits[digit];
                if (number == null) return;
                key /= 10;
            } while (key > 0);

            // ToDo: Clear the path
            number.IsLastDigit = false;
        }

        public bool Contains(int key)
        {
            var number = Root;
            do
            {
                if (number.NextDigits == null) return false;
                var digit = key % 10;
                number = number.NextDigits[digit];
                if (number == null) return false;
                key /= 10;
            } while (key > 0);

            return number.IsLastDigit;
        }
    }

    public class Test
    {
        private readonly ITestOutputHelper _testOutput;
        public Test(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Theory]
        [InlineData(new[] { 4, 3, 2, 7, 8, 2, 3, 1 }, new[] { 5, 6 })]
        [InlineData(new[] { 1, 1, 2, 2, 3, 3 }, new[] { 4, 5, 6 })]
        public void Check(int[] input, int[] expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            solution.Run(input).Should().BeEquivalentTo(expectedOutput);
            timer.Stop();
            _testOutput.WriteLine($"{timer.ElapsedTicks}");
        }

        [Fact]
        public void Check_This()
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            solution.Run(new[] { 4, 3, 2, 7, 8, 2, 3, 1 }).Should().BeEquivalentTo(new[] { 5, 6 });
            timer.Stop();
            _testOutput.WriteLine($"{timer.ElapsedTicks}");
        }
    }
}