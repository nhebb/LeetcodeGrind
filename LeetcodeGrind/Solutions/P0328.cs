using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 328. Odd Even Linked List
public class P0328
{
    public ListNode OddEvenList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;

        var odd = head;
        var even = head.next;
        var evenPrev = new ListNode(0);
        evenPrev.next = even;

        while (even != null && even.next != null)
        {
            odd.next = even.next;
            even.next = even.next.next;
            if (odd.next != null)
                odd = odd.next;
            even = even.next;
        }

        odd.next = evenPrev.next;
        return head;
    }
}
