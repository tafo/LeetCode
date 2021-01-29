using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using LeetCode.Problems.Common;

namespace LeetCode.Problems.Medium.RemoveNthNodeFromEndOfList
{
    [SimpleJob(RunStrategy.Monitoring, RuntimeMoniker.NetCoreApp31)]
    public class Benchmark
    {
        public List<Tuple<ListNode, int>> Data;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var random = new Random();
            Data = new List<Tuple<ListNode, int>>
            {
                new Tuple<ListNode, int>(Enumerable.Range(0, 10).ToListNode(), random.Next(1, 11)),
                new Tuple<ListNode, int>(Enumerable.Range(0, 100).ToListNode(), random.Next(1, 101)),
                new Tuple<ListNode, int>(Enumerable.Range(0, 1000).ToListNode(), random.Next(1, 1001)),
            };
        }

        /// <summary>
        /// ToDo : Check
        /// </summary>
        public IEnumerable<object[]> InputAndOutput()
        {
            yield return new object[]
            {
                new List<int> {1, 2, 3, 4, 5}.ToListNode(), 2
            };
            yield return new object[]
            {
                new List<int> {1}.ToListNode(), 1
            };
        }

        [Benchmark]
        public void SolutionWithStoring()
        {
            var solution = new SolutionWithFastAndSlow();
            foreach (var (head, n) in Data)
            {
                solution.RemoveNthFromEnd(head, n);   
            }
        }

        [Benchmark]
        public void SolutionWithFastAndSlow()
        {
            var solution = new SolutionWithStoring();
            foreach (var (head, n) in Data)
            {
                solution.RemoveNthFromEnd(head, n);   
            }
        }
    }
}