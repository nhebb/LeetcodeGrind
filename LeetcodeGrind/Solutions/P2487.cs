using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2487. Remove Nodes From Linked List
public class P2487
{
    public ListNode RemoveNodes(ListNode head)
    {
        if (head == null)
            return head;

        // Filter the nodes using a Monotonic Stack
        var stack = new Stack<ListNode>();
        stack.Push(head);
        head = head.next;

        while (head != null)
        {
            // While the top stack node's value is less than the
            // current node's value, discard the top node in stack.
            while (stack.Count > 0 && stack.Peek().val < head.val)
            {
                _ = stack.Pop();
            }

            // Then add the current node to the stack.
            stack.Push(head);

            head = head.next;
        }

        // Rebuild the LinkedList from right to left.
        var lastNode = stack.Pop();
        lastNode.next = null;
        while (stack.Count > 0)
        {
            stack.Peek().next = lastNode;
            lastNode = stack.Pop();
        }

        return lastNode;
    }
}
