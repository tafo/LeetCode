using System.Collections.Generic;
using LeetCode.Problems.Common;

namespace LeetCode.Problems.Hard.ReverseKGroup
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-nodes-in-k-group/
    /// </summary>
    public class Solution
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var resultList = new List<ListNode>();
            var list = new List<ListNode>();
            var node = head;
            while (node != null)
            {
                list.Add(node);
                node = node.next;
                if (list.Count == k)
                {
                    list.Reverse();
                    resultList.AddRange(list);
                    list.Clear();
                }
            }

            if (list.Count > 0)
            {
                resultList.AddRange(list);
            }

            var root = resultList[0];
            node = root;
            for (int i = 1; i < resultList.Count; i++)
            {
                node.next = resultList[i];
                node = node.next;
            }

            node.next = null;

            return root;
        }
    }
}