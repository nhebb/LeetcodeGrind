using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 147. Insertion Sort List
public class P0147
{
    public ListNode InsertionSortList(ListNode head)
    {
        var list = new List<int>();

        while (head != null)
        {
            var index = list.BinarySearch(head.val);
            if (index < 0)
                index = ~index;
            list.Insert(index, head.val);
            head = head.next;
        }

        var node = new ListNode(list[0]);
        var prev = new ListNode(0);
        prev.next = node;

        for (int i = 1; i < list.Count; i++)
        {
            node.next = new ListNode(list[i]);
            node = node.next;
        }

        return prev.next;
    }
}
