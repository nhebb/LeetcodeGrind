using LeetcodeGrind.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetcodeGrind.LinkedLists;

public class LinkedLists
{
    // 2. Add Two Numbers
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var head = new ListNode();
        var node = new ListNode();
        node.next = head;

        int carry = 0;

        while (l1 != null || l2 != null)
        {
            if (node.next == null)
            {
                node.next = new ListNode();
            }
            node = node.next;

            int val = carry;
            if (l1 != null)
            {
                val += l1.val;
                l1 = l1.next;
            }
            if (l2 != null)
            {
                val += l2.val;
                l2 = l2.next;
            }

            node.val = val % 10;
            carry = val / 10;
        }

        if (carry > 0)
        {
            node.next = new ListNode(carry, null);
        }

        return head;
    }


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
    // TODO: 25. Reverse Nodes in k-Group
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


    // 138. Copy List with Random Pointer
    public RandomNode CopyRandomList(RandomNode head)
    {
        if (head == null)
            return null;

        var node1 = head;
        var prev = new RandomNode(0);
        var node2 = new RandomNode(head.val);
        prev.next = node2;

        var d = new Dictionary<RandomNode, RandomNode>();
        d[node1] = node2;

        // populate deep copy
        while (node1.next != null)
        {
            node2.next = new RandomNode(node1.next.val);
            node1 = node1.next;
            node2 = node2.next;
            d[node1] = node2;
        }

        node1 = head;
        node2 = prev.next;

        // populate random pointers
        while (node1 != null)
        {
            if (node1.random != null)
                node2.random = d[node1.random];

            node1 = node1.next;
            node2 = node2.next;
        }

        return prev.next;
    }


    // 114. Flatten Binary Tree to Linked List
    public void Flatten(TreeNode root)
    {
        if (root == null) return;

        var nodes = new List<TreeNode>();

        void Dfs(TreeNode node)
        {
            if (node == null) return;

            nodes.Add(node);
            Dfs(node.left);
            Dfs(node.right);
        }

        Dfs(root);

        for (int i = 0; i < nodes.Count - 1; i++)
        {
            nodes[i].left = null;
            nodes[i].right = nodes[i + 1];
        }

        nodes[^1].left = null;
        nodes[^1].right = null;

    }


    // 160. Intersection of Two Linked Lists
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


    // 61. Rotate List
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null || head.next == null || k == 0)
            return head;

        var nodes = new List<ListNode>();
        var node = head;
        while (node != null)
        {
            nodes.Add(node);
            node = node.next;
        }

        if (k > nodes.Count)
            k %= nodes.Count;

        if (k == 0)
            return head;

        var headIndex = nodes.Count - k;
        if (headIndex == 0)
            return head;

        nodes[^1].next = nodes[0];
        nodes[headIndex - 1].next = null;
        return nodes[headIndex];
    }


    // TODO: 92. Reverse Linked List II
    //public ListNode ReverseBetween(ListNode head, int left, int right)
    //{

    //}


    // 86. Partition List
    public ListNode Partition(ListNode head, int x)
    {
        if (head == null)
            return head;

        var lower = new List<ListNode>();
        var higher = new List<ListNode>();

        var node = head;
        while (node != null)
        {
            if (node.val < x)
                lower.Add(node);
            else
                higher.Add(node);

            node = node.next;
        }

        lower.AddRange(higher);

        for (int i = 1; i < lower.Count; i++)
            lower[i - 1].next = lower[i];
        lower[^1].next = null;

        return lower[0];
    }


    // 203. Remove Linked List Elements
    public ListNode RemoveElements(ListNode head, int val)
    {
        if (head == null)
            return head;

        ListNode prev = new ListNode(0);
        prev.next = head;
        ListNode node = prev;

        while (node.next != null)
        {
            if (node.next.val == val)
                node.next = node.next.next;
            else
                node = node.next;
        }

        return prev.next;
    }


    // 83. Remove Duplicates from Sorted List
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null)
            return head;

        var node = head;
        while (node.next != null)
        {
            if (node.val == node.next.val)
                node.next = node.next.next;
            else
                node = node.next;
        }
        return head;
    }


    // 328. Odd Even Linked List
    public ListNode OddEvenList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;

        var odd = head;
        var even = head.next;
        var evenPrev = new ListNode(0);
        evenPrev.next = even;

        while (even != null && even.next != null)
        {
            odd.next = even.next;
            even.next = even.next.next;
            if(odd.next != null)
                odd = odd.next;
            even = even.next;
        }

        odd.next = evenPrev.next;
        return head;
    }
}
