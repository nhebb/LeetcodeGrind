using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 99. Recover Binary Search Tree
public class P0099
{
    public void RecoverTree(TreeNode root)
    {
        TreeNode maxNode = null;

        // Idea: change Dfs to have min, max, and direction parameters
        void Dfs(TreeNode node)
        {
            if (node is null)
                return;

            if (maxNode != null)
            {
                if (node.val < maxNode.val)
                {
                    (maxNode.val, node.val) = (node.val, maxNode.val);
                    return;
                }
                maxNode = node;
            }

            // Find the first leaf node and set maxNode
            if (node.left is null &&
                node.right is null &&
                maxNode is null)
            {
                maxNode = node;
            }

            Dfs(node.left);
            Dfs(node.right);
        }

        Dfs(root);
    }
}
