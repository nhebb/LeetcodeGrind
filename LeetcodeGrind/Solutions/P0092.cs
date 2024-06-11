using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 92. Reverse Linked List II
public class P0092
{
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        var node = head;
        var prev = new ListNode();
        prev.next = head;
        var i = 1;

        while (i < left)
        {
            node = node.next;
            prev = prev.next; // trails 'node' by 1
            i++;
        }

        var stack = new Stack<ListNode>();
        while (i <= right)
        {
            if (left == 1)
            {
                head = node;
            }

            stack.Push(node);
            node = node.next;
            i++;
        }

        while (stack.Count > 0)
        {
            prev.next = stack.Pop();
            prev = prev.next;
        }
        prev.next = node;

        return head;
    }
}
