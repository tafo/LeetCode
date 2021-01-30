using System.Collections.Generic;
using LeetCode.Problems.Common;

namespace LeetCode.Problems.Medium.RemoveNthNodeFromEndOfList
{
    /// <summary>
    /// Problem: https://leetcode.com/problems/remove-nth-node-from-end-of-list/
    /// </summary>
    public class SolutionWithStoring
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var nodeList = new List<ListNode>();
            var node = head;
            while (node != null)
            {
                nodeList.Add(node);
                node = node.next;
            }

            if (nodeList.Count == 1) return null;
            if (nodeList.Count < n + 1) return head.next;
            nodeList[^(n + 1)].next = n == 1 ? null : nodeList[^(n - 1)];
            return head;
        }
    }
}