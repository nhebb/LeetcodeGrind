using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 101. Symmetric Tree
public class P0101
{
    public bool IsSymmetric(TreeNode root)
    {
        if (root == null)
            return true;

        bool DFS(TreeNode node1, TreeNode node2)
        {
            if (node1 == null && node2 == null)
                return true;

            if ((node1 == null && node2 != null) ||
                (node1 != null && node2 == null))
                return false;

            if (node1.val != node2.val)
                return false;

            return DFS(node1.left, node2.right) &&
                   DFS(node1.right, node2.left);
        }

        return DFS(root.left, root.right);
    }
}
