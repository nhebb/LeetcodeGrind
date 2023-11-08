namespace LeetcodeGrind.Solutions.NextRightNode;

// Note: Problems 116 and 117 are grouped together since they
// have a custom definition of Node, which is difference than
// the one defined in namespace LeetcodeGrind.Common.

public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}

public class NextRightTree
{
    // 116. Populating Next Right Pointers in Each Node
    public Node Connect(Node root)
    {
        if (root == null) return root;

        var levels = new List<List<Node>>();
        var q = new Queue<(Node node, int level)>();
        q.Enqueue((root, 0));

        while (q.Count > 0)
        {
            var item = q.Dequeue();
            if (item.level == levels.Count)
                levels.Add(new List<Node>());
            levels[item.level].Add(item.node);

            if (item.node.left != null)
                q.Enqueue((item.node.left, item.level + 1));
            if (item.node.right != null)
                q.Enqueue((item.node.right, item.level + 1));
        }

        for (int i = 0; i < levels.Count; i++)
        {
            var last = levels[i].Count - 1;
            for (int j = 0; j < last; j++)
            {
                levels[i][j].next = levels[i][j + 1];
            }
            levels[i][^1].next = null;
        }

        return root;
    }


    // 117. Populating Next Right Pointers in Each Node II
    // Follow-up:
    //  - You may only use constant extra space.
    //  - The recursive approach is fine. You may assume implicit
    //    stack space does not count as extra space for this problem.

    public Node ConnectII(Node root)
    {
        if (root == null) return root;

        var levels = new List<List<Node>>();
        var q = new Queue<(Node node, int level)>();
        q.Enqueue((root, 0));

        while (q.Count > 0)
        {
            var item = q.Dequeue();
            if (item.level == levels.Count)
                levels.Add(new List<Node>());
            levels[item.level].Add(item.node);

            if (item.node.left != null)
                q.Enqueue((item.node.left, item.level + 1));
            if (item.node.right != null)
                q.Enqueue((item.node.right, item.level + 1));
        }

        for (int i = 0; i < levels.Count; i++)
        {
            var last = levels[i].Count - 1;
            for (int j = 0; j < last; j++)
            {
                levels[i][j].next = levels[i][j + 1];
            }
            levels[i][^1].next = null;
        }

        return root;
    }
}
