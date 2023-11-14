using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 111. Minimum Depth of Binary Tree
public class P0111
{
    public int MinDepth(TreeNode root)
    {
        if (root == null) return 0;
        var minDepth = int.MaxValue;

        void Dfs(TreeNode node, int depth)
        {
            if (node == null) return;

            if (node.left == null && node.right == null)
            {
                minDepth = Math.Min(minDepth, depth);
                return;
            }
            Dfs(node.left, depth + 1);
            Dfs(node.right, depth + 1);
        }

        Dfs(root, 1);

        return minDepth;
    }
}
