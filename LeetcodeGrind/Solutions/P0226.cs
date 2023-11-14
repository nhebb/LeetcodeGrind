using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 226. Invert Binary Tree
public class P0226
{
    public TreeNode InvertTree(TreeNode root)
    {
        void FlipNodes(TreeNode node)
        {
            if (node == null)
                return;

            (node.left, node.right) = (node.right, node.left);

            FlipNodes(node.left);
            FlipNodes(node.right);
        }

        FlipNodes(root);

        return root;
    }
}
