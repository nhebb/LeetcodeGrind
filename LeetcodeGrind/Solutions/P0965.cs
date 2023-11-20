using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 965. Univalued Binary Tree
public class P0965
{
    public bool IsUnivalTree(TreeNode root)
    {
        bool Dfs(TreeNode node, int parentValue)
        {
            if (node == null)
                return true;

            if (node.val != parentValue)
                return false;

            return Dfs(node.left, node.val)
                && Dfs(node.right, node.val);
        }

        return Dfs(root.left, root.val)
            && Dfs(root.right, root.val);
    }
}
