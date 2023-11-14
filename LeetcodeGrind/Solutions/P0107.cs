using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 107. Binary Tree Level Order Traversal II
public class P0107
{
    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        var d = new Dictionary<int, IList<int>>();
        var maxLevel = -0;

        void Dfs(TreeNode node, int level)
        {
            maxLevel = Math.Max(maxLevel, level);

            if (!d.ContainsKey(level))
                d[level] = new List<int>();
            d[level].Add(node.val);

            if (node.left != null)
                Dfs(node.left, level + 1);
            if (node.right != null)
                Dfs(node.right, level + 1);
        }

        var ans = new List<IList<int>>();
        if (root == null)
            return ans;

        Dfs(root, 0);

        for (int i = maxLevel; i >= 0; i--)
            ans.Add(d[i]);

        return ans;
    }
}
