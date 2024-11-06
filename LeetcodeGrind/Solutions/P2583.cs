using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2583. Kth Largest Sum in a Binary Tree
public class P2583
{
    public long KthLargestLevelSum(TreeNode root, int k)
    {
        var levelSums = new Dictionary<int, long>();

        void Dfs(TreeNode node, int level)
        {
            if (node == null)
            {
                return;
            }

            if (levelSums.TryGetValue(level, out long value))
            {
                levelSums[level] = value + node.val;
            }
            else
            {
                levelSums[level] = node.val;
            }

            Dfs(node.left, level + 1);
            Dfs(node.right, level + 1);
        }

        Dfs(root, 0);

        var sums = levelSums.Values.ToList();
        if (sums.Count < k)
        {
            return -1;
        }

        return sums.OrderByDescending(x => x).ToArray()[k - 1];
    }
}
