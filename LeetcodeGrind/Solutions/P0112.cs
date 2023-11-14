using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 112. Path Sum
public class P0112
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root == null)
            return false;

        if (root.left == null && root.right == null)
            return root.val == targetSum;

        targetSum -= root.val;

        return HasPathSum(root.left, targetSum)
            || HasPathSum(root.right, targetSum);
    }
}
