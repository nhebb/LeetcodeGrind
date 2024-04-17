using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 623. Add One Row to Tree
public class P0623
{
    public TreeNode AddOneRow(TreeNode root, int val, int depth)
    {
        if (root is null || depth == 1)
        {
            return new TreeNode(val, root, null);
        }

        void Dfs(TreeNode node, int level)
        {
            if (node is null)
                return;

            if (level == depth - 1)
            {
                var tempLeft = node.left;
                node.left = new TreeNode(val);
                node.left.left = tempLeft;

                var tempRight = node.right;
                node.right = new TreeNode(val);
                node.right.right = tempRight;

                return;
            }

            Dfs(node.left, level + 1);
            Dfs(node.right, level + 1);
        }

        Dfs(root, 1);

        return root;
    }
}
