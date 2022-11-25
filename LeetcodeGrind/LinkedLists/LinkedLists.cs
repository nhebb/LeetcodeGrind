using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.LinkedLists;

public class LinkedLists
{
    // 19. Remove Nth Node From End of List
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        if (n <= 0)
            return head;

        if (head == null || (head.next == null && n == 1))
            return null;

        var n1 = head;
        int count = 0;
        while (n1 != null)
        {
            count++;
            n1 = n1.next;
        }

        if (n == count)
            return head.next;

        var prev = new ListNode(0);
        prev.next = head;
        var n2 = head;

        for (int i = 0; i < count - n - 1; i++)
        {
            n2 = n2.next;
        }
        n2.next = n2.next.next;

        return prev.next;
    }


    // 21. Merge Two Sorted Lists
    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        if (l1 == null) { return l2; }
        if (l2 == null) { return l1; }

        var prev = new ListNode();
        var node = prev;

        while (l1 != null && l2 != null)
        {
            if (l1.val <= l2.val)
            {
                node.next = l1;
                l1 = l1.next;
            }
            else
            {
                node.next = l2;
                l2 = l2.next;
            }
            node = node.next;
        }

        if (l1 == null && l2 != null)
        {
            node.next = l2;
        }
        else if (l1 != null && l2 == null)
        {
            node.next = l1;
        }

        return prev.next;
    }


    // 143. Reorder List
    public void ReorderList(ListNode head)
    {
        if (head == null || head.next == null)
            return;

        var stack = new Stack<ListNode>();
        stack.Push(head);

        int count = 0;
        var node = head;
        while (node.next != null)
        {
            stack.Push(node.next);
            node = node.next;
            count++;
        }

        int maxCount = count / 2;
        count = 0;
        node = head;

        while (count <= maxCount)
        {
            var temp = node.next;
            node.next = stack.Pop();
            node.next.next = temp;
            node = temp;

            count++;
            if (count > maxCount)
            {
                temp.next.next = null;
            }
        }
    }


    // 141. Linked List Cycle

    public bool HasCycle(ListNode head)
    {
        // two pointers solution
        if (head == null) { return false; }

        var slow = head;
        var fast = head;
        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast) { return true; }
        }
        return false;
    }
    public bool HasCycle2(ListNode head)
    {
        // hashset solution
        var hs = new HashSet<ListNode>();

        while (head != null)
        {
            if (!hs.Add(head)) { return true; }
            head = head.next;
        }

        return false;
    }


    // 206. Reverse Linked List
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


    // 23. Merge k Sorted Lists
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0) { return null; }

        PriorityQueue<ListNode, int> pq = new PriorityQueue<ListNode, int>();
        foreach (ListNode enqueNode in lists)
        {
            if (enqueNode != null)
            {
                pq.Enqueue(enqueNode, enqueNode.val);
            }
        }

        ListNode prev = new ListNode(Int32.MinValue);
        ListNode node = prev;

        while (pq.Count > 0)
        {
            node.next = pq.Dequeue();
            node = node.next;
            if (node.next != null)
            {
                pq.Enqueue(node.next, node.next.val);
            }
        }

        return prev.next;
    }

    //24. Swap Nodes in Pairs
    public ListNode SwapPairs(ListNode head)
    {
        if (head == null || head.next == null)
            return head;

        var prev = new ListNode();
        prev.next = head.next;

        var node = head.next.next;
        head.next.next = head;
        head.next = SwapPairs(node);

        return prev.next;
    }


    // 25. Reverse Nodes in k-Group
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
    // TODO: Finsih this problem
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

        return prev.next;
    }
}
