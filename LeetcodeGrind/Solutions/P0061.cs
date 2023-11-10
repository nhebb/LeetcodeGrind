using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 61. Rotate List
public class P0061
{
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null || head.next == null || k == 0)
            return head;

        var nodes = new List<ListNode>();
        var node = head;
        while (node != null)
        {
            nodes.Add(node);
            node = node.next;
        }

        if (k > nodes.Count)
            k %= nodes.Count;

        if (k == 0)
            return head;

        var headIndex = nodes.Count - k;
        if (headIndex == 0)
            return head;

        nodes[^1].next = nodes[0];
        nodes[headIndex - 1].next = null;
        return nodes[headIndex];
    }
}
