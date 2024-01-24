using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1372. Longest ZigZag Path in a Binary Tree
public class P1372
{
    public int LongestZigZag(TreeNode root)
    {
        if (root is null) return 0;

        var max = 0;

        void Dfs(TreeNode node, int tally, int dir)
        {
            if (node is null) return;

            tally++;
            max = Math.Max(max, tally);

            if (dir == -1)
            {
                Dfs(node.left, 0, dir);
                Dfs(node.right, tally, -dir);
            }
            else
            {
                Dfs(node.left, tally, -dir);
                Dfs(node.right, 0, dir);
            }
        }

        Dfs(root.left, 0, -1);
        Dfs(root.right, 0, 1);

        return max;
    }
}
