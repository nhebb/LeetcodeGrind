using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 671. Second Minimum Node In a Binary Tree
public class P0671
{
    public int FindSecondMinimumValue(TreeNode root)
    {
        var min2 = -1;

        void Dfs(TreeNode node, int parentVal)
        {
            if (node == null) return;

            if (node.val != parentVal)
            {
                if (min2 == -1)
                    min2 = node.val;
                else if (node.val < min2)
                    min2 = node.val;
            }

            Dfs(node.left, node.val);
            Dfs(node.right, node.val);
        }

        Dfs(root.left, root.val);
        Dfs(root.right, root.val);

        return min2;
    }
}
