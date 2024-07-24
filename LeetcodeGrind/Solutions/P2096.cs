using LeetcodeGrind.Common;
using System.Text;

namespace LeetcodeGrind.Solutions;

// 2096. Step-By-Step Directions From a Binary Tree Node to Another
public class P2096
{
    public string GetDirections(TreeNode root, int startValue, int destValue)
    {
        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder();

        bool Dfs(TreeNode node, int target, StringBuilder path)
        {
            if (node == null)
                return false;

            if (node.val == target)
                return true;

            if (Dfs(node.left, target, path))
            {
                path.Append('L');
                return true;
            }

            if (Dfs(node.right, target, path))
            {
                path.Append('R');
                return true;
            }

            return false;
        }

        _ = Dfs(root, startValue, sb1);
        _ = Dfs(root, destValue, sb2);

        var startPath = string.Join("", sb1.ToString().Reverse());
        var destPath = string.Join("", sb2.ToString().Reverse());

        var i = 0;
        for (i = 0; i < startPath.Length && i < destPath.Length; i++)
        {
            if (startPath[i] != destPath[i])
            {
                break;
            }
        }

        return new string('U', startPath.Length - i) +
               destPath.Substring(i, destPath.Length - i);
    }
}
