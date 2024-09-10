using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2807. Insert Greatest Common Divisors in Linked List
public class P2807
{
    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        var prev = new ListNode(0, head);

        while (head != null && head.next != null)
        {
            var val = Gcd(head.val, head.next.val);
            var node = new ListNode(val, head.next);
            head.next = node;
            head = head.next.next;
        }

        return prev.next;
    }

    private int Gcd(int a, int b)
    {
        if (b == 0)
            return a;

        return Gcd(b, a % b);
    }
}
