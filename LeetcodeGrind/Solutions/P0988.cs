using System.Text;
using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 988. Smallest String Starting From Leaf
public class P0988
{
    public string SmallestFromLeaf(TreeNode root)
    {
        return Dfs(root, "");
    }

    private string Dfs(TreeNode node, string parentChar)
    {
        var c = ((char)('a' + node.val)).ToString();

        if (node.left == null && node.right == null)
            return c;

        if (node.left != null && node.right == null)
            return Dfs(node.left, c) + c;

        if (node.left == null && node.right != null)
            return Dfs(node.right, c) + c;

        var sLeft = Dfs(node.left, c) + c;
        var sRight = Dfs(node.right, c) + c;

        return (sLeft + parentChar).CompareTo(sRight + parentChar) < 0
            ? sLeft
            : sRight;
    }
}
