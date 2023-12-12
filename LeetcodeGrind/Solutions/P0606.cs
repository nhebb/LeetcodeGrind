using LeetcodeGrind.Common;
using System.Text;

namespace LeetcodeGrind.Solutions;

// 606. Construct String from Binary Tree
public class P0606
{
    public string Tree2str(TreeNode root)
    {
        var sb = new StringBuilder();
        sb.Append(root.val);


        if (root.left != null && root.right != null)
        {
            Dfs(root.left, sb);
            Dfs(root.right, sb);
        }
        else if (root.left == null && root.right != null)
        {
            sb.Append("()");
            Dfs(root.right, sb);
        }
        else if (root.left != null && root.right == null)
        {
            Dfs(root.left, sb);
        }

        return sb.ToString();
    }

    private void Dfs(TreeNode node, StringBuilder sb)
    {
        sb.Append('(').Append(node.val);
        if (node.left != null && node.right != null)
        {
            Dfs(node.left, sb);
            Dfs(node.right, sb);
        }
        else if (node.left == null && node.right != null)
        {
            sb.Append("()");
            Dfs(node.right, sb);
        }
        else if (node.left != null && node.right == null)
        {
            Dfs(node.left, sb);
        }
        sb.Append(')');
    }
}

