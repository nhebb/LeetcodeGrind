using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 572. Subtree of Another Tree
public class P0572
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (root == null) 
            return false;

        bool DfsMatch(TreeNode r, TreeNode s)
        {
            if (r == null && s == null)
                return true;

            if (r == null || s == null || r.val != s.val)
                return false;

            return DfsMatch(r.left, s.left)
                && DfsMatch(r.right, s.right);
        }

        if (DfsMatch(root, subRoot))
            return true;

        return IsSubtree(root.left, subRoot) ||
               IsSubtree(root.right, subRoot);
    }
}
