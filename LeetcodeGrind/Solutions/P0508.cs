using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 508. Most Frequent Subtree Sum
public class P0508
{
    public int[] FindFrequentTreeSum(TreeNode root)
    {
        var d = new Dictionary<int, int>();
        var freq = new List<int>();
        var maxFreq = 0;

        int Dfs(TreeNode node)
        {
            if (node == null)
                return 0;

            var sum = node.val + Dfs(node.left) + Dfs(node.right);

            if (d.TryGetValue(sum, out var val))
                d[sum] = val + 1;
            else
                d[sum] = 1;

            if (d[sum] == maxFreq)
            {
                freq.Add(sum);
            }
            else if (d[sum] > maxFreq)
            {
                maxFreq = d[sum];
                freq.Clear();
                freq.Add(sum);
            }

            return sum;
        }

        Dfs(root);

        return freq.ToArray();
    }
}
