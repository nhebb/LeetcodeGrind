using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 203. Remove Linked List Elements
public class P0203
{
    public ListNode RemoveElements(ListNode head, int val)
    {
        if (head == null)
            return head;

        ListNode prev = new ListNode(0);
        prev.next = head;
        ListNode node = prev;

        while (node.next != null)
        {
            if (node.next.val == val)
                node.next = node.next.next;
            else
                node = node.next;
        }

        return prev.next;
    }
}
