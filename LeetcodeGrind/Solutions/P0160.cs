using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 160. Intersection of Two Linked Lists
public class P0160
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        var hs = new HashSet<ListNode>();

        while (headA != null)
        {
            hs.Add(headA);
            headA = headA.next;
        }

        while (headB != null)
        {
            if (!hs.Add(headB))
                return headB;
            headB = headB.next;
        }

        return null;
    }
}
