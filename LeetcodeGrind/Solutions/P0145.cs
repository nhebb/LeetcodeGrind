using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 145. Binary Tree Postorder Traversal
public class P0145
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var postorder = new List<int>() { };

        void Dfs(TreeNode node)
        {
            if (node == null)
                return;

            Dfs(node.left);
            Dfs(node.right);

            postorder.Add(node.val);
        }

        Dfs(root);

        return postorder;
    }
}
