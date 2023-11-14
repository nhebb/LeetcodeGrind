using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 144. Binary Tree Preorder Traversal
public class P0144
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var preorder = new List<int> { };

        void Dfs(TreeNode node)
        {
            if (node == null) return;
            preorder.Add(node.val);
            Dfs(node.left);
            Dfs(node.right);
        }

        Dfs(root);

        return preorder;
    }
}

