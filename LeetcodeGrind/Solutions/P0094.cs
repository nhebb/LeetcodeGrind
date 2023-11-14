using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 94. Binary Tree Inorder Traversal
public class P0094
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        var list = new List<int>();

        void DFS(TreeNode node)
        {
            if (node == null) return;

            DFS(node.right);
            list.Add(node.val);
            DFS(node.right);
        }

        DFS(root);

        return list;
    }
}
