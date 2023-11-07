using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetcodeGrind.Common;

namespace LeetcodeGrind.Trees;

// 173. Binary Search Tree Iterator
public class BSTIterator
{
    int index = -1;
    List<TreeNode> nodes;

    public BSTIterator(TreeNode root)
    {
        nodes = new List<TreeNode>();
        CreateNodeList(root);
    }

    public int Next()
    {
        index++;
        return nodes[index].val;
    }

    public bool HasNext()
    {
        return index < nodes.Count - 1;
    }

    private void CreateNodeList(TreeNode node)
    {
        if (node == null)
            return;

        if (node.left != null)
            CreateNodeList(node.left);

        nodes.Add(node);

        if(node.right != null)
            CreateNodeList(node.right);
    }
}
