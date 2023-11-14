using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 617. Merge Two Binary Trees
public class P0617
{
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        if (root1 == null)
            return root2;

        if (root2 == null)
            return root1;

        void Dfs(TreeNode node1, TreeNode node2)
        {
            node1.val += node2.val;

            if (node1.left == null && node2.left != null)
                node1.left = node2.left;
            else if (node2.left != null)
                Dfs(node1.left, node2.left);

            if (node1.right == null && node2.right != null)
                node1.right = node2.right;
            else if (node2.right != null)
                Dfs(node1.right, node2.right);
        }

        Dfs(root1, root2);

        return root1;
    }
}
