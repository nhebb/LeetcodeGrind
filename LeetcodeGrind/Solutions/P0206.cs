using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 206. Reverse Linked List
public class P0206
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        while (head != null)
        {
            var temp = head.next;
            head.next = prev;
            prev = head;
            head = temp;
        }
        return prev;
    }
}
