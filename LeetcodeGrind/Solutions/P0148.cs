using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 148. Sort List
public class P0148
{
    // Brute / O(n) memory: Copy values into list, sort,
    // repopulate ordered values back into linked list.
    // The proper way to do this with O(1) memory is to
    // do a merge sort in place with the linked list,
    // but I never use linked lists in C#, so frankly
    // I don't care.
    public ListNode SortList(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        var list = new List<int>();
        var node = head;
        while (node != null)
        {
            list.Add(node.val);
            node = node.next;
        }

        list.Sort();
        node = head;
        for (int i = 0; i < list.Count; i++)
        {
            node.val = list[i];
            node = node.next;
        }

        return head;
    }
}
