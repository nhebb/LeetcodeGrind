using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 235. Lowest Common Ancestor of a Binary Search Tree
public class P0235
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        // if p or q == root.val, then root is LCA
        if (p.val == root.val || q.val == root.val)
            return root;

        // if p and q fork paths, root is LCA
        if ((p.val < root.val && q.val > root.val) ||
            (p.val > root.val && q.val < root.val))
            return root;

        // if p & q < root, recurse left
        if (p.val < root.val && q.val < root.val)
            return LowestCommonAncestor(root.left, p, q);

        // only remaining option is to go right
        return LowestCommonAncestor(root.right, p, q);
    }
}
