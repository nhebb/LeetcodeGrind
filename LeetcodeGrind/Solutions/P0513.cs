using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 513. Find Bottom Left Tree Value
public class P0513
{
    public int FindBottomLeftValue(TreeNode root)
    {
        var levels = new List<IList<int>>();

        void Dfs(TreeNode node, int depth)
        {
            if (node == null)
                return;

            if (depth == levels.Count)
            {
                levels.Add(new List<int>());
            }
            levels[depth].Add(node.val);

            Dfs(node.left, depth + 1);
            Dfs(node.right, depth + 1);
        }

        Dfs(root, 0);

        return levels[^1][0];
    }
}
