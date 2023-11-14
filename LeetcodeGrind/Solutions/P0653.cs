using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 653. Two Sum IV - Input is a BST
public class P0653
{
    public bool FindTarget(TreeNode root, int k)
    {
        var hs = new HashSet<int>();

        // Inorder traversal checking for:
        //      target + node.val = k
        //   => target = k - node.val
        bool Dfs(TreeNode node)
        {
            if (node.left != null && Dfs(node.left))
                return true;

            if (hs.Contains(k - node.val))
                return true;

            hs.Add(node.val);

            if (node.right != null && Dfs(node.right))
                return true;

            return false;
        }

        return Dfs(root);
    }
}
