using LeetcodeGrind.Common;
using System.Text;

namespace LeetcodeGrind.Solutions;

// 234. Palindrome Linked List
public class P0234
{
    // O(n) time && O(n) space
    public bool IsPalindrome(ListNode head)
    {
        if (head == null)
            return false;
        if (head.next == null)
            return true;

        var list = new List<int>();
        while (head != null)
        {
            list.Add(head.val);
            head = head.next;
        }

        var i = 0;
        var j = list.Count - 1;
        while (i < j)
        {
            if (list[i] != list[j])
                return false;
            i++;
            j--;
        }
        return true;
    }

    // O(n) time && O(1) space (theoretically, but both
    // solutions had about the same runtime and memory).
    public bool IsPalindrome2(ListNode head)
    {
        if (head == null)
            return false;
        if (head.next == null)
            return true;

        var slow = head;
        var fast = head;
        var prev = new ListNode(0, null);
        var next = new ListNode(0, null);

        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            next = slow.next;
            slow.next = prev;
            prev = slow;
            slow = next;
        }

        if (fast != null)
            slow = slow.next; // odd # of nodes - skip middle

        while (slow != null)
        {
            if (slow.val != prev.val)
                return false;

            slow = slow.next;
            prev = prev.next;
        }

        return true;
    }
}
