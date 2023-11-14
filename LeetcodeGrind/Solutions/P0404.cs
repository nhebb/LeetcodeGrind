using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 404. Sum of Left Leaves
public class P0404
{
    public int SumOfLeftLeaves(TreeNode root)
    {
        var sum = 0;

        void Dfs(TreeNode node, bool isLeft)
        {
            if (node == null) return;

            if (isLeft && node.left == null && node.right == null)
            {
                sum += node.val;
                return;
            }

            Dfs(node.left, true);
            Dfs(node.right, false);
        }

        Dfs(root, false);

        return sum;
    }
}
