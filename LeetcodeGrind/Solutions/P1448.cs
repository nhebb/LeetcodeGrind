using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1448. Count Good Nodes in Binary Tree
public class P1448
{
    public int GoodNodes(TreeNode root)
    {
        var good = 1;

        void Dfs(TreeNode node, int maxVal)
        {
            if (node == null)
                return;

            if (node.val >= maxVal)
            {
                good++;
                maxVal = node.val;
            }

            Dfs(node.left, maxVal);
            Dfs(node.right, maxVal);
        }

        Dfs(root.left, root.val);
        Dfs(root.right, root.val);

        return good;
    }
}
