using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 141. Linked List Cycle
public class P0141
{
    public bool HasCycle(ListNode head)
    {
        // two pointers solution
        if (head == null) { return false; }

        var slow = head;
        var fast = head;
        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast) { return true; }
        }
        return false;
    }

    public bool HasCycle2(ListNode head)
    {
        // hashset solution
        var hs = new HashSet<ListNode>();

        while (head != null)
        {
            if (!hs.Add(head)) { return true; }
            head = head.next;
        }

        return false;
    }
}
