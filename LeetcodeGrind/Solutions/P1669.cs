using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1669. Merge In Between Linked Lists
public class P1669
{
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
    {
        var prev1 = new ListNode(0, list1);
        var count = 0;

        while (count < a)
        {
            prev1 = prev1.next; 
            count++;
        }
        count--;
        var prev2 = prev1;

        while (count < b)
        {
            prev2 = prev2.next;
            count++;
        }

        var node = list2;
        while (node.next != null)
        {
            node = node.next;
        }

        prev1.next = list2;
        node.next = prev2.next;

        return list1;
    }
}
