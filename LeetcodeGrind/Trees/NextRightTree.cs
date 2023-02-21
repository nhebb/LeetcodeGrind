using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Trees;


// Note: LC problem uses 'Node'. I renamed it to NRNode
//       due to scope collision
internal class NRNode
{
    public int val;
    public NRNode left;
    public NRNode right;
    public NRNode next;

    public NRNode() { }

    public NRNode(int _val)
    {
        val = _val;
    }

    public NRNode(int _val, NRNode _left, NRNode _right, NRNode _next)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
internal class NextRightTree
{
    // 116. Populating Next Right Pointers in Each Node
    public NRNode Connect(NRNode root)
    {
        if (root == null) return root;

        var levels = new List<List<NRNode>>();
        var q = new Queue<(NRNode node, int level)>();
        q.Enqueue((root, 0));

        while (q.Count > 0)
        {
            var item = q.Dequeue();
            if (item.level == levels.Count)
                levels.Add(new List<NRNode>());
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

    public NRNode ConnectII(NRNode root)
    {
        if (root == null) return root;

        var levels = new List<List<NRNode>>();
        var q = new Queue<(NRNode node, int level)>();
        q.Enqueue((root, 0));

        while (q.Count > 0)
        {
            var item = q.Dequeue();
            if (item.level == levels.Count)
                levels.Add(new List<NRNode>());
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

    public void TestNRNode()
    {
        var root = new NRNode(1);
        root.left = new NRNode(2);
        root.right = new NRNode(3);
        root.left.left = new NRNode(4);
        root.left.right = new NRNode(5);
        root.right.left = new NRNode(6);
        root.right.right = new NRNode(7);

        _ = Connect(root);
    }
}
