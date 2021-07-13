using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Easy.IsIsomorphic
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
        public void CheckAnother(string s, string t, bool output)
        {
            var timer = Stopwatch.StartNew();
            var solution = new SolutionAnother();
            timer.Start();
            var actualOutput = solution.IsIsomorphic(s, t);
            timer.Stop();
            actualOutput.Should().Be(output);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        [Theory]
        [MemberData(nameof(InputAndOutput))]
        public void CheckLibero(string s, string t, bool output)
        {
            var timer = Stopwatch.StartNew();
            var solution = new SolutionLibero();
            timer.Start();
            var actualOutput = solution.IsIsomorphic(s, t);
            timer.Stop();
            actualOutput.Should().Be(output);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        [Theory]
        [MemberData(nameof(InputAndOutput))]
        public void CheckBest(string s, string t, bool output)
        {
            var timer = Stopwatch.StartNew();
            var solution = new SolutionBest();
            timer.Start();
            var actualOutput = solution.IsIsomorphic(s, t);
            timer.Stop();
            actualOutput.Should().Be(output);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                "egg",
                "add",
                true
            },
            new object[]
            {
                "foo",
                "bar",
                false
            },
            new object[]
            {
                "paperpaperpaperpaperpaperpaperpaperpaperpaperpaperpaperpaperpaperpaper",
                "titletitletitletitletitletitletitletitletitletitletitletitletitletitle",
                true
            },            
            new object[]
            {
                "badc",
                "baba",
                false
            },
            new object[]
            {
                "badcbadcbadcbadcbadcbadcbadcbadcbadcbadcbadcbadcbadcbadcbadcbadc",
                "babababababababababababababababababababababababababababababababa",
                false
            },
        };
    }
}
