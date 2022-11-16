using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Trees;

public class Trees
{
    // 144. Binary Tree Preorder Traversal
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


    // 145. Binary Tree Postorder Traversal
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var postorder = new List<int> { };
        void Dfs(TreeNode node)
        {
            if (node == null) return;
            Dfs(node.left);
            Dfs(node.right);
            postorder.Add(node.val);
        }
        Dfs(root);
        return postorder;
    }
}
