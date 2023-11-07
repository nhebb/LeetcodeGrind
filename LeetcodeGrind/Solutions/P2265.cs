using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2265. Count Nodes Equal to Average of Subtree
public class P2265
{
    public int AverageOfSubtree(TreeNode root)
    {
        var totalCount = 0;

        (int, int) Dfs(TreeNode node)
        {
            if (node == null)
                return (0, 0);

            var (leftSum, leftCount) = Dfs(node.left);
            var (rightSum, rightCount) = Dfs(node.right);

            var sum = node.val + leftSum + rightSum;
            var count = 1 + leftCount + rightCount;

            if (sum / count == node.val)
                totalCount++;

            return (sum, count);
        }

        Dfs(root);

        return totalCount;
    }
}
