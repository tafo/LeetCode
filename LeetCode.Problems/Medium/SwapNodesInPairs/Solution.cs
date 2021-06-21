using LeetCode.Problems.Common;

namespace LeetCode.Problems.Medium.SwapNodesInPairs
{
    /// <summary>
    /// https://leetcode.com/problems/swap-nodes-in-pairs/
    /// </summary>
    public class Solution
    {
        public ListNode SwapPairs(ListNode head)
        {
            var dummyHead = new ListNode {next = head};
            var previous = dummyHead;
            while (head?.next != null)
            {
                var second = head.next;
                head.next = second.next;
                second.next = head;
                previous.next = second;
                previous = head;
                head = head.next;
            }

            return dummyHead.next;
        }
    }
}