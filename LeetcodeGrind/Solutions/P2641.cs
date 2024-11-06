using LeetcodeGrind.Common;
using LeetcodeGrind.NAryTree;

namespace LeetcodeGrind.Solutions;

// 2641. Cousins in Binary Tree II
public class P2641
{
    public TreeNode ReplaceValueInTree(TreeNode root)
    {
        var levels = new List<IList<TreeNode>>();
        var levelSums = new List<int>();

        void BuildLevelList(TreeNode node, int level)
        {
            if (node == null)
                return;

            if (levels.Count == level)
                levels.Add(new List<TreeNode>());
            levels[level].Add(node);

            if (levelSums.Count == level)
                levelSums.Add(node.val);
            else
                levelSums[level] += node.val;

            BuildLevelList(node.left, level + 1);
            BuildLevelList(node.right, level + 1);
        }

        BuildLevelList(root, 0);

        for (int i = levels.Count - 2; i > 0; i--)
        {
            var level = levels[i];
            for (int j = 0; j < level.Count; j++)
            {
                var childrenValues = levelSums[i + 1];
                childrenValues -= level[j].left == null ? 0 : level[j].left.val;
                childrenValues -= level[j].right == null ? 0 : level[j].right.val;

                if (level[j].left != null)
                    level[j].left.val = childrenValues;
                if (level[j].right != null)
                    level[j].right.val = childrenValues;
            }
        }

        root.val = 0;
        if (root.left != null)
            root.left.val = 0;
        if(root.right != null)
            root.right.val = 0;

        return root;
    }
}
