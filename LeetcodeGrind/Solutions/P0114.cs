using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 114. Flatten Binary Tree to Linked List
public class P0114
{
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
}
