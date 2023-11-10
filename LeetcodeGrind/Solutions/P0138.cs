namespace LeetcodeGrind.Solutions.P0138;

// 138. Copy List with Random Pointer
public class P0138
{
    // This is a different definition of Node than the one defined
    // in the LeetcodeGrind.Common namespace that is used in other
    // linked list problems.
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    public Node CopyRandomList(Node head)
    {
        if (head == null)
            return null;

        var node1 = head;
        var prev = new Node(0);
        var node2 = new Node(head.val);
        prev.next = node2;

        var d = new Dictionary<Node, Node>();
        d[node1] = node2;

        // populate deep copy
        while (node1.next != null)
        {
            node2.next = new Node(node1.next.val);
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
}
