using LeetcodeGrind.Common;
using System.Text;

namespace LeetcodeGrind.Solutions;

// 129. Sum Root to Leaf Numbers
public class P0129
{
    public int SumNumbers(TreeNode root)
    {
        var sb = new StringBuilder();
        var sum = 0;

        void Dfs(TreeNode node)
        {
            sb.Append(node.val);
            if (node.left == null && node.right == null)
            {
                sum += int.Parse(sb.ToString());
            }
            if (node.left != null) Dfs(node.left);
            if (node.right != null) Dfs(node.right);

            sb.Remove(sb.Length - 1, 1);
        }

        Dfs(root);

        return sum;
    }
}
