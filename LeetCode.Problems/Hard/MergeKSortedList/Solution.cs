using LeetCode.Problems.Common;

namespace LeetCode.Problems.Hard.MergeKSortedList
{
    /// <summary>
    /// Problem: https://leetcode.com/problems/merge-k-sorted-lists/
    /// </summary>
    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;

            var index = 1;

            while (index < lists.Length)
            {
                lists[0] = Merge(lists[0], lists[index++]);
            }

            return lists[0];

            static ListNode Merge(ListNode l1, ListNode l2)
            {
                if (l1 == null) return l2;
                if (l2 == null) return l1;
                if (l1.val < l2.val)
                {
                    l1.next = Merge(l1.next, l2);
                    return l1;
                }

                l2.next = Merge(l1, l2.next);
                return l2;
            }
        }
    }
}