using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 700. Search in a Binary Search Tree
public class P0700
{
    public TreeNode SearchBST(TreeNode root, int val)
    {
        if (root == null || root.val == val)
            return root;

        if (val < root.val)
            return SearchBST(root.left, val);

        return SearchBST(root.right, val);
    }
}
