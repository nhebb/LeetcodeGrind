using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2181. Merge Nodes in Between Zeros
public class P2181
{
    public ListNode MergeNodes(ListNode head)
    {
        var prev = new ListNode();
        var node = prev;

        while (true)
        {
            if (head.val == 0)
                head = head.next;

            if (head == null)
                break;

            int sum = 0;
            while (head.val != 0)
            {
                sum += head.val;
                head = head.next;
            }
            node.next = new ListNode(sum);
            node = node.next;
        }

        return prev.next;
    }
}
