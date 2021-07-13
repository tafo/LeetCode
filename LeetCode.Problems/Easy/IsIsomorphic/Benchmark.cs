using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace LeetCode.Problems.Easy.IsIsomorphic
{
    public class Benchmark
    {
        public List<Tuple<string, string>> Data;

        [GlobalSetup]
        public void GlobalSetup()
        {
            Data = new List<Tuple<string, string>>
            {
                new("egg", "add"),
                new("foo", "bar"),
                new(
                    "paperpaperpaperpaperpaperpaperpaperpaperpaperpaperpaperpaperpaperpaper",
                    "titletitletitletitletitletitletitletitletitletitletitletitletitletitle"),
                new("badc", "baba"),
                new(
                    "badcbadcbadcbadcbadcbadcbadcbadcbadcbadcbadcbadcbadcbadcbadcbadc",
                    "babababababababababababababababababababababababababababababababa")
            };
        }

        [Benchmark]
        public void SolutionBest()
        {
            var solution = new SolutionBest();
            foreach (var (s, t) in Data)
            {
                solution.IsIsomorphic(s, t);
            }
        }

        [Benchmark]
        public void SolutionLibero()
        {
            var solution = new SolutionLibero();
            foreach (var (s, t) in Data)
            {
                solution.IsIsomorphic(s, t);
            }
        }

        [Benchmark]
        public void SolutionAnother()
        {
            var solution = new SolutionAnother();
            foreach (var (s, t) in Data)
            {
                solution.IsIsomorphic(s, t);
            }
        }
    }
}
