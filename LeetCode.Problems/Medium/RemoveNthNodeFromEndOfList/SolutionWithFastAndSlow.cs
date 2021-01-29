using LeetCode.Problems.Common;

namespace LeetCode.Problems.Medium.RemoveNthNodeFromEndOfList
{
    public class SolutionWithFastAndSlow
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var start = new ListNode();
            ListNode slow = start, fast = start;
            slow.next = head;

            for (var i = 1; i <= n + 1; i++)
            {
                fast = fast.next;
            }

            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next;
            }

            slow.next = slow.next.next;
            return start.next;
        }
    }
}