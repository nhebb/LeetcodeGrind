using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 86. Partition List
public class P0086
{
    public ListNode Partition(ListNode head, int x)
    {
        if (head == null)
            return head;

        var lower = new List<ListNode>();
        var higher = new List<ListNode>();

        var node = head;
        while (node != null)
        {
            if (node.val < x)
                lower.Add(node);
            else
                higher.Add(node);

            node = node.next;
        }

        lower.AddRange(higher);

        for (int i = 1; i < lower.Count; i++)
            lower[i - 1].next = lower[i];
        lower[^1].next = null;

        return lower[0];
    }
}
