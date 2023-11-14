using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 513. Find Bottom Left Tree Value
public class P0513
{
    public int FindBottomLeftValue(TreeNode root)
    {
        var maxDepth = 0;
        var minCol = 0;
        var result = root.val;

        void Dfs(TreeNode node, int depth, int col)
        {
            if (depth > maxDepth
                || (depth == maxDepth && col < minCol))
            {
                maxDepth = depth;
                minCol = col;
                result = node.val;
            }

            if (node.left != null)
                Dfs(node.left, depth + 1, col - 1);

            if (node.right != null)
                Dfs(node.right, depth + 1, col + 1);
        }

        Dfs(root, 0, 0);

        return result;
    }
}
