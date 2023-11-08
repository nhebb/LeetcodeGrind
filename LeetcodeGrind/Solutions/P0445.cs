using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 445. Add Two Numbers II
public class P0445
{
    public ListNode? AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var s1 = new Stack<int>();
        var s2 = new Stack<int>();
        ListNode? nextNode = null;

        while (l1 != null)
        {
            s1.Push(l1.val);
            l1 = l1.next;
        }
        while (l2 != null)
        {
            s2.Push(l2.val);
            l2 = l2.next;
        }

        var carry = 0;
        ListNode? node = null;
        while (s1.Count > 0 || s2.Count > 0)
        {
            var num1 = s1.Count > 0 ? s1.Pop() : 0;
            var num2 = s2.Count > 0 ? s2.Pop() : 0;
            var sum = num1 + num2 + carry;
            var val = sum % 10;
            carry = sum / 10;
            node = new ListNode(val);
            node.next = nextNode;
            nextNode = node;
        }

        if (carry > 0)
        {
            node = new ListNode(carry);
            node.next = nextNode;
        }

        return node;
    }
}
