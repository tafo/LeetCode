using LeetCode.Problems.Common;

namespace LeetCode.Problems.Easy.MergeTwoSortedList
{
    public class SolutionWithRecursion
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }

            l2.next = MergeTwoLists(l1, l2.next);
            return l2;
        }
    }
}
