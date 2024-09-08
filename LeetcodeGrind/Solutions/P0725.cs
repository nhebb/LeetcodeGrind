using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 725. Split Linked List in Parts
public class P0725
{
    public ListNode[] SplitListToParts(ListNode head, int k)
    {
        var node = head;
        var count = 0;
        while (node != null)
        {
            count++;
            node = node.next;
        }

        var rem = count % k;
        var size = (count / k) + 1;
        var result = new ListNode[k];
        var lastNodes = new List<ListNode>();
        var i = 0;
        while (i < k)
        {
            if (i == rem)
                size--;

            result[i] = head;
            var j = 0;
            while (head != null && j < size)
            {
                if(j == size -1)
                    lastNodes.Add(head);
                head = head.next;
                j++;
            }
            i++;
            if (head == null)
                break;
        }

        while (i < k)
        {
            result[i] = null;
            i++;
        }

        foreach (var lastNode in lastNodes)
        {
            lastNode.next = null;
        }

        return result;
    }
}
