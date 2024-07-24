using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1110. Delete Nodes And Return Forest
public class P1110
{
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
    {
        var hs = to_delete.ToHashSet();
        var result = new List<TreeNode>();

        // postorder traversal
        void Dfs(TreeNode parent, TreeNode node, char dir)
        {
            if (node == null)
                return;

            Dfs(node, node.left, 'L');
            Dfs(node, node.right, 'R');

            if (hs.Contains(node.val))
            {
                if (dir == 'L')
                    parent.left = null;
                else
                    parent.right = null;
            }
            else if (hs.Contains(parent.val))
            {
                result.Add(node);
            }
        }

        var prev = new TreeNode(-1);
        if (root != null && !hs.Contains(root.val))
        {
            result.Add(root);
        }

        Dfs(prev, root, 'N');

        return result;
    }
}
