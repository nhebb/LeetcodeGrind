using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1171. Remove Zero Sum Consecutive Nodes from Linked List
public class P1171
{
    public ListNode RemoveZeroSumSublists(ListNode head)
    {
        var prev = new ListNode(0, head);
        var node = prev;
        
        var prefixNodes = new Dictionary<int, ListNode>();
        int prefix = 0;

        while (node != null)
        {
            prefix += node.val;
            if (prefixNodes.TryGetValue(prefix, out ListNode? value))
            {
                var curNode = value;
                var curSum = prefix;

                while (curNode != null && curNode.next != node)
                {
                    curNode = curNode.next;
                    curSum += curNode.val;
                    prefixNodes.Remove(curSum);
                }

                value.next = node.next;
            }
            else
            {
                prefixNodes.Add(prefix, node);
            }

            node = node.next;
        }

        return prev.next;
    }
}
