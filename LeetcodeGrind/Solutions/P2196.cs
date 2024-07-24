using LeetcodeGrind.Common;
using System.Diagnostics;

namespace LeetcodeGrind.Solutions;

// 2196. Create Binary Tree From Descriptions
public class P2196
{
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        var d = new Dictionary<int, (TreeNode node, bool hasParent)>();
        foreach (var desc in descriptions)
        {
            TreeNode parent;
            if (d.TryGetValue(desc[0], out (TreeNode node, bool hasParent) value))
            {
                parent = value.node;
            }
            else
            {
                parent = new TreeNode(desc[0]);
                d[desc[0]] = (parent, false);
            }

            TreeNode child;
            if (d.TryGetValue(desc[1], out (TreeNode node, bool hasParent) value2))
            {
                child = value2.node;
            }
            else
            {
                child = new TreeNode(desc[1]);
            }
            d[desc[1]] = (child, true);

            if (desc[2] == 1)
            {
                parent.left = child;
            }
            else
            {
                parent.right = child;
            }
        }

        foreach (var kvp in d)
        {
            if (!kvp.Value.hasParent)
            {
                return kvp.Value.node;
            }
        }

        return null;
    }
}
