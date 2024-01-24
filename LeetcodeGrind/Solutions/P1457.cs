using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1457. Pseudo-Palindromic Paths in a Binary Tree
public class P1457
{
    public int PseudoPalindromicPaths(TreeNode root)
    {
        var digitCounts = new int[10];
        var count = 0;

        void Dfs(TreeNode node)
        {
            digitCounts[node.val]++;
            if (node.left == null && node.right == null)
            {
                if (digitCounts.Count(x => x % 2 == 1) <= 1)
                    count++;
            }
            else
            {
                if (node.left != null)
                    Dfs(node.left);
                if (node.right != null)
                    Dfs(node.right);
            }
            digitCounts[node.val]--;
        }
        Dfs(root);

        return count;
    }
}
