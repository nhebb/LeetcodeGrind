using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2. Add Two Numbers
public class P0002
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var head = new ListNode();
        var node = new ListNode();
        node.next = head;

        int carry = 0;

        while (l1 != null || l2 != null)
        {
            if (node.next == null)
            {
                node.next = new ListNode();
            }
            node = node.next;

            int val = carry;
            if (l1 != null)
            {
                val += l1.val;
                l1 = l1.next;
            }
            if (l2 != null)
            {
                val += l2.val;
                l2 = l2.next;
            }

            node.val = val % 10;
            carry = val / 10;
        }

        if (carry > 0)
        {
            node.next = new ListNode(carry, null);
        }

        return head;
    }
}
