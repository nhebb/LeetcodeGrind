using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 104. Maximum Depth of Binary Tree
public class P0104
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null)
            return 0;

        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }
}
