using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 563. Binary Tree Tilt
public class P0563
{
    public int FindTilt(TreeNode root)
    {
        if (root == null)
            return 0;

        var tilt = 0;

        int Dfs(TreeNode node)
        {
            if (node == null) return 0;
            var leftSum = Dfs(node.left);
            var rightSum = Dfs(node.right);
            tilt += Math.Abs(leftSum - rightSum);
            return leftSum + rightSum + node.val;
        }

        Dfs(root);

        return tilt;
    }
}
