using System;
using BenchmarkDotNet.Running;

namespace LeetCode.Benchmark
{
    public class Program
    {
        public static void Main()
        {
            Console.ReadLine();
            BenchmarkRunner.Run(typeof(Problems.Medium.RemoveNthNodeFromEndOfList.Benchmark));
            Console.ReadLine();
        }
    }
}
