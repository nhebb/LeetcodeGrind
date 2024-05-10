using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 237. Delete Node in a Linked List
public class P0237
{
    public void DeleteNode(ListNode node)
    {
        if (node.next == null)
        {
            node = null;
        }
        else
        {
            node.val = node.next.val;
            var nextNode = node.next;
            node.next = node.next.next;
            nextNode = null;
        }
    }
}
