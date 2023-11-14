using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 783. Minimum Distance Between BST Nodes
public class P0783
{
    public int MinDiffInBST(TreeNode root)
    {
        var vals = new List<int>();
        void Dfs(TreeNode node)
        {
            if (node.left != null)
                Dfs(node.left);

            vals.Add(node.val);

            if (node.right != null)
                Dfs(node.right);
        }

        Dfs(root);

        var minDiff = vals[1] - vals[0];
        for (int i = 2; i < vals.Count; i++)
        {
            var diff = vals[i] - vals[i - 1];
            if (diff < minDiff)
                minDiff = diff;
        }
        return minDiff;
    }
}
