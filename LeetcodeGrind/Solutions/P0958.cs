using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 958. Check Completeness of a Binary Tree
public class P0958
{
    public bool IsCompleteTree(TreeNode root)
    {
        if (root == null)
            return true;

        var levels = new List<List<int>>();

        void Dfs(TreeNode node, int level, int index)
        {
            if (node == null)
                return;

            if (level == levels.Count)
                levels.Add(new List<int>());

            levels[level].Add(index);

            Dfs(node.left, level + 1, 2 * index - 1);
            Dfs(node.right, level + 1, 2 * index);
        }

        Dfs(root, 0, 1);

        for (int i = 0; i < levels.Count - 1; i++)
        {
            if (levels[i].Count != Math.Pow(2, i))
                return false;
        }

        var lastRow = levels[^1];

        for (int i = 0; i < lastRow.Count; i++)
        {
            if (lastRow[i] != i + 1)
                return false;
        }

        return true;
    }
}
