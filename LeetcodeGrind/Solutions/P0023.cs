using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 23. Merge k Sorted Lists
public class P0023
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0) { return null; }

        var pq = new PriorityQueue<ListNode, int>();
        foreach (var enqueNode in lists)
        {
            if (enqueNode != null)
            {
                pq.Enqueue(enqueNode, enqueNode.val);
            }
        }

        var prev = new ListNode(Int32.MinValue);
        var node = prev;

        while (pq.Count > 0)
        {
            node.next = pq.Dequeue();
            node = node.next;
            if (node.next != null)
            {
                pq.Enqueue(node.next, node.next.val);
            }
        }

        return prev.next;
    }
}
