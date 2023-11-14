using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1325. Delete Leaves With a Given Value
public class P1325
{
    public TreeNode RemoveLeafNodes(TreeNode root, int target)
    {
        TreeNode DeleteLeaf(TreeNode node)
        {
            if (node == null)
                return null;

            node.left = DeleteLeaf(node.left);
            node.right = DeleteLeaf(node.right);

            if (node.val == target
                && node.left == null
                && node.right == null)
            {
                return null;
            }

            return node;
        }

        root.left = DeleteLeaf(root.left);
        root.right = DeleteLeaf(root.right);

        if (root.val == target
            && root.left == null
            && root.right == null)
        {
            return null;
        }

        return root;
    }
}
