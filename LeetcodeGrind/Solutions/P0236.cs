using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 236. Lowest Common Ancestor of a Binary Tree
public class P0236
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        TreeNode result = null;

        bool Dfs(TreeNode node)
        {
            if (node == null)
            {
                return false;
            }

            var current = node.val == p.val || node.val == q.val;
            var left = Dfs(node.left);
            var right = Dfs(node.right);

            if (result == null)
            {
                if (left && right || current && left || current && right)
                {
                    result = node;
                    return true;
                }
            }

            return current || left || right;
        }

        Dfs(root);

        return result;
    }
}
