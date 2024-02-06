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

    public ListNode ReverseBetween2(ListNode head, int left, int right)
    {
        var node = head;
        var prev = new ListNode();
        prev.next = node;

        // Locate left node
        while (node.val != left && node.next != null)
        {
            prev = node;
            node = node.next;
        }

        ListNode ReverseSegmwnt(ListNode head)
        {
            ListNode prev = null;
            while (head.val != right)
            {
                var temp = head.next;
                head.next = prev;
                prev = head;
                head = temp;
            }
            return prev;
        }

        // Reverse list up to right node
        var prev2 = prev;
        var end = node;
        while (node.val != right && node.next != null)
        {
            prev2.next = node.next;
            node.next = node.next.next;
            prev2.next.next = node;
        }

        return head;
    }
}
