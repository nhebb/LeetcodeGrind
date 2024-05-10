using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2816. Double a Number Represented as a Linked List
public class P2816
{
    public ListNode DoubleIt(ListNode head)
    {
        if (head is null)
        {
            return head;
        }

        var prev = new ListNode(0, head);
        var node = head;
        var carry = 0;
        var stack = new Stack<ListNode>();

        while (node is not null)
        {
            stack.Push(node);
            node = node.next;
        }

        while (stack.Count > 0)
        {
            node = stack.Pop();
            var newVal = node.val * 2 + carry;
            node.val = newVal % 10;
            carry = newVal / 10;
        }

        if (carry > 0)
        {
            prev.val = carry;
            return prev;
        }

        return head;
    }
}
