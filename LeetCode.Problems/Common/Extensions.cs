using System.Collections.Generic;
using FluentAssertions.Collections;

namespace LeetCode.Problems.Common
{
    public static class Extensions
    {
        public static ListNode ToListNode(this IEnumerable<int> numbers)
        {
            ListNode root = null;
            ListNode current = null;
            foreach (var number in numbers)
            {
                if (root == null)
                {
                    root = new ListNode(number);
                    current = root;
                }
                else
                {
                    current.next = new ListNode(number);
                    current = current.next;
                }
            }

            return root;
        }

        public static bool IsEqualTo(this ListNode firstNode, ListNode secondNode)
        {
            while (firstNode != null && secondNode != null)
            {
                var value1 = firstNode.val;
                var value2 = secondNode.val;
                if (value1 != value2) return false;
                firstNode = firstNode.next;
                secondNode = secondNode.next;
            }

            return firstNode == null && secondNode == null;
        }

        public static void BeEqualTo<T>(
            this GenericCollectionAssertions<T> set, 
            IEnumerable<T> other,
            string testCase = null)
        {
            set.BeEquivalentTo(other, options => options.WithStrictOrdering(), testCase);
        }

        public static IEnumerable<int> ToList(this ListNode node)
        {
            if (node == null) return null;
            var output = new List<int>();
            while (node != null)
            {
                output.Add(node.val);
                node = node.next;
            }

            return output;
        }
    }
}