using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 19. Remove Nth Node From End of List
public class P0019
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        if (n <= 0)
            return head;

        if (head == null || (head.next == null && n == 1))
            return null;

        var n1 = head;
        int count = 0;
        while (n1 != null)
        {
            count++;
            n1 = n1.next;
        }

        if (n == count)
            return head.next;

        var prev = new ListNode(0);
        prev.next = head;
        var n2 = head;

        for (int i = 0; i < count - n - 1; i++)
        {
            n2 = n2.next;
        }
        n2.next = n2.next.next;

        return prev.next;
    }
}
