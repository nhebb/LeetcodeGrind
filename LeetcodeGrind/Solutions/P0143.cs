using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 143. Reorder List
public class P0143
{
    public void ReorderList(ListNode head)
    {
        if (head == null || head.next == null)
            return;

        var stack = new Stack<ListNode>();
        stack.Push(head);

        int count = 0;
        var node = head;
        while (node.next != null)
        {
            stack.Push(node.next);
            node = node.next;
            count++;
        }

        int maxCount = count / 2;
        count = 0;
        node = head;

        while (count <= maxCount)
        {
            var temp = node.next;
            node.next = stack.Pop();
            node.next.next = temp;
            node = temp;

            count++;
            if (count > maxCount)
            {
                temp.next.next = null;
            }
        }
    }
}
