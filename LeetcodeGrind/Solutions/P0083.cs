using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 83. Remove Duplicates from Sorted List
public class P0083
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null)
            return head;

        var node = head;
        while (node.next != null)
        {
            if (node.val == node.next.val)
                node.next = node.next.next;
            else
                node = node.next;
        }
        return head;
    }
}
