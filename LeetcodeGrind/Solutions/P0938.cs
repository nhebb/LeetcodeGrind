using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 938. Range Sum of BST
public class P0938
{
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        if (root == null)
            return 0;

        int val = (root.val >= low && root.val <= high)
            ? root.val
            : 0;

        val += RangeSumBST(root.left, low, high);
        val += RangeSumBST(root.right, low, high);

        return val;
    }
}
