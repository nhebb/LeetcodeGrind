using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

//24. Swap Nodes in Pairs
public class P0024
{
    public ListNode SwapPairs(ListNode head)
    {
        if (head == null || head.next == null)
            return head;

        var prev = new ListNode();
        prev.next = head.next;

        var node = head.next.next;
        head.next.next = head;
        head.next = SwapPairs(node);

        return prev.next;
    }
}
