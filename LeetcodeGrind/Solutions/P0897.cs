using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 897. Increasing Order Search Tree
public class P0897
{
    public TreeNode IncreasingBST(TreeNode root)
    {
        if (root == null)
            return root;

        var nodes = new List<TreeNode>();

        void CreateList(TreeNode node)
        {
            if (node.left != null)
                CreateList(node.left);

            nodes.Add(node);

            if (node.right != null)
                CreateList(node.right);
        }

        CreateList(root);
        for (int i = 0; i < nodes.Count - 1; i++)
        {
            nodes[i].left = null;
            nodes[i].right = nodes[i + 1];
        }

        nodes[^1].left = null;
        nodes[^1].right = null;

        return nodes[0];
    }
}
