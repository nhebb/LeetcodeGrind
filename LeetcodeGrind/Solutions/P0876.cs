using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 
public class P0876
{
    //  876. Middle of the Linked List
    public ListNode MiddleNode(ListNode head)
    {
        if (head == null) { return head; }

        var slow = head;
        var fast = head;
        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        if (fast.next != null)
        {
            slow = slow.next;
        }

        return slow;
    }
}
