using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 110. Balanced Binary Tree
public class P0110
{
    public bool IsBalanced(TreeNode root)
    {
        bool balanced = true;

        int DepthDFS(TreeNode node)
        {
            if (node == null) return 0;

            int leftDepth = DepthDFS(node.left);
            int rightDepth = DepthDFS(node.right);

            if (Math.Abs(leftDepth - rightDepth) > 1)
                balanced = false;

            return 1 + Math.Max(leftDepth, rightDepth);
        }

        _ = DepthDFS(root);

        return balanced;
    }
}
