using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 543. Diameter of Binary Tree
public class P0543
{
    public int DiameterOfBinaryTree(TreeNode root)
    {
        var maxPath = 0;

        int Dfs(TreeNode node)
        {
            if (node == null) return 0;

            var left = Dfs(node.left);
            var right = Dfs(node.right);
            var path = left + right;
            maxPath = Math.Max(maxPath, path);
            return 1 + Math.Max(left, right);
        }

        Dfs(root);

        return maxPath;
    }
}
