using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1022. Sum of Root To Leaf Binary Numbers
public class P1022
{
    public int SumRootToLeaf(TreeNode root)
    {
        if (root == null) return 0;

        var sum = 0;

        void Dfs(TreeNode node, int val)
        {
            var curVal = node.val;
            val = (val << 1) | curVal;

            if (node.left == null && node.right == null)
            {
                sum += val;
                return;
            }

            if (node.left != null)
                Dfs(node.left, val);

            if (node.right != null)
                Dfs(node.right, val);
        }

        Dfs(root, 0);

        return sum;
    }
}
