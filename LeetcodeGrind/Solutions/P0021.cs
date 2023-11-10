using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 21. Merge Two Sorted Lists
public class P0021
{
    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        if (l1 == null) { return l2; }
        if (l2 == null) { return l1; }

        var prev = new ListNode();
        var node = prev;

        while (l1 != null && l2 != null)
        {
            if (l1.val <= l2.val)
            {
                node.next = l1;
                l1 = l1.next;
            }
            else
            {
                node.next = l2;
                l2 = l2.next;
            }
            node = node.next;
        }

        if (l1 == null && l2 != null)
        {
            node.next = l2;
        }
        else if (l1 != null && l2 == null)
        {
            node.next = l1;
        }

        return prev.next;
    }
}
