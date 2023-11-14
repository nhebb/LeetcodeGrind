using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 662. Maximum Width of Binary Tree
public class P0662
{
    public int WidthOfBinaryTree(TreeNode root)
    {
        if (root == null)
            return 0;

        var d = new Dictionary<int, long[]>();
        void CountLevels(TreeNode node, int level, long index)
        {
            if (node == null) return;

            if (d.ContainsKey(level))
            {
                d[level][0] = Math.Min(d[level][0], index);
                d[level][1] = Math.Max(d[level][1], index);
            }
            else
            {
                d[level] = new long[2] { index, index };
            }

            CountLevels(node.left, level + 1, 2 * index - 1);
            CountLevels(node.right, level + 1, 2 * index);
        }

        CountLevels(root, 1, 1);

        long max = 0;
        foreach (var kvp in d)
        {
            var width = kvp.Value[1] - kvp.Value[0] + 1;
            if (width > max)
                max = width;
        }

        return (int)max;
    }
}
