using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 92. Reverse Linked List II
// TODO: Finish this.
public class P0092
{
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        var prev = new ListNode(0);
        prev.next = head;
        var curr = prev;
        var i = 1;

        while (i < left)
        {
            head = head.next;
            curr = curr.next;
            i++;
        }

        var stack = new Stack<ListNode>();
        while (i <= right)
        {
            stack.Push(head);
            head = head.next;
            i++;
        }

        curr.next = stack.Peek();
        var nextNode = stack.Peek().next;
        // Console.WriteLine($"stack.Count = {stack.Count}");
        Console.WriteLine($"head.val = {head.val}");

        while (stack.Count > 0)
        {
            head.next = stack.Pop();
            head = head.next;
        }
        head.next = nextNode;
        var res = prev.next;
        return res;
    }
}
