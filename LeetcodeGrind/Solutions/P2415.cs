using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2415. Reverse Odd Levels of Binary Tree
public class P2415
{
    public TreeNode ReverseOddLevels(TreeNode root)
    {
        var d = new Dictionary<int, List<TreeNode>>();
        void BuildDictionary(TreeNode node, int level)
        {
            if (node == null) return;
            if (level % 2 == 1)
            {
                if (!d.ContainsKey(level))
                    d[level] = new List<TreeNode>();
                d[level].Add(node);
            }
            BuildDictionary(node.left, level + 1);
            BuildDictionary(node.right, level + 1);
        }

        BuildDictionary(root, 0);

        foreach (var kvp in d)
        {
            var i = 0;
            var j = kvp.Value.Count - 1;
            while (i < j)
            {
                var temp = kvp.Value[i].val;
                kvp.Value[i].val = kvp.Value[j].val;
                kvp.Value[j].val = temp;
                i++;
                j--;
            }
        }

        return root;
    }
}
