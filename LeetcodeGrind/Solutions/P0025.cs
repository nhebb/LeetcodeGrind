using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 25. Reverse Nodes in k-Group
// TODO: Finish this.
/* Given the head of a linked list, reverse the nodes of the list k at a time,
 * and return the modified list.

k is a positive integer and is less than or equal to the length of the linked 
list. If the number of nodes is not a multiple of k then left-out nodes, 
in the end, should remain as it is.

You may not alter the values in the list's nodes, only nodes themselves may 
be changed.

Constraints:
    The number of nodes in the list is n.
    1 <= k <= n <= 5000
    0 <= Node.val <= 1000

*/
public class P0025
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        var prev = new ListNode();
        // do the first k nodes to get the head value to return
        var fast = head;
        var slow = head;
        var i = k;

        // this may be off by 1
        while (i > 0 && fast != null)
        {
            fast = fast.next;
            i--;
        }
        if (i > 1)
            return head;

        prev.next = fast;
        var nextNode = fast.next;

        for (i = 0; i < k; i++)
        {
            var temp = slow.next;

        }

        return prev.next;
    }
}

