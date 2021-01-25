using LeetCode.Problems.Common;

namespace LeetCode.Problems.Medium.AddTwoNumbers
{
    public class Solution
    {
        /// <summary>
        /// Runtime: 100 ms, faster than 96.72% of C# online submissions for Add Two Numbers.
        /// Memory Usage: 27.3 MB, less than 90.22% of C# online submissions for Add Two Numbers.
        /// </summary>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var tempHeadNode = new ListNode();
            var currentNode = tempHeadNode;
            var carry = 0;
            do
            {
                var value1 = l1?.val ?? 0;
                var value2 = l2?.val ?? 0;
                var sum = value1 + value2 + carry;
                carry = sum / 10;
                var nextNode = new ListNode
                {
                    val = sum > 9 ? sum - 10 : sum
                };
                currentNode.next = nextNode;
                currentNode = currentNode.next;
                l1 = l1?.next;
                l2 = l2?.next;
            } while (l1 != null || l2 != null);

            if (carry == 1)
            {
                currentNode.next = new ListNode(1);
            }

            return tempHeadNode.next;
        }
    }
}