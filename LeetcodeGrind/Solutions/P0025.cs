using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 25. Reverse Nodes in k-Group
public class P0025
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        var stack = new Stack<ListNode>();
        var prev = new ListNode();
        prev.next = head;
        var last = prev; // last node in a set of k
        var isFirstSet = true;

        while (head != null)
        {
            var i = 0;
            while (head != null && i < k)
            {
                stack.Push(head);
                head = head.next;
                i++;
            }

            if (i < k)
            {
                break;
            }

            if (isFirstSet)
            {
                prev.next = stack.Peek();
                isFirstSet = false;
            }

            while (stack.Count > 0)
            {
                last.next = stack.Pop();
                last = last.next;
            }

            last.next = head;
        }

        return prev.next;
    }
}

