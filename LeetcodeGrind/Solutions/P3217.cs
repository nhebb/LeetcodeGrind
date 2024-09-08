using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 3217. Delete Nodes From Linked List Present in Array
public class P3217
{
    public ListNode ModifiedList(int[] nums, ListNode head)
    {
        var hs = nums.ToHashSet();

        while (head != null && head.next != null && hs.Contains(head.val))
        {
            head = head.next;
        }
        var prev = new ListNode(0, head);
        var node = prev;

        while (node != null)
        {
            while (node.next != null && hs.Contains(node.next.val))
                node.next = node.next.next;
            node = node.next;
        }

        return prev.next;
    }
}
