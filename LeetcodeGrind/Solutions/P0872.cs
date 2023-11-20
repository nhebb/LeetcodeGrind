using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 872. Leaf-Similar Trees
public class P0872
{
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        var leaves1 = new List<int>();
        var leaves2 = new List<int>();

        void Dfs(TreeNode node, List<int> leaves)
        {
            if (node == null)
                return;

            if (node.left == null && node.right == null)
            {
                leaves.Add(node.val);
                return;
            }

            Dfs(node.left, leaves);
            Dfs(node.right, leaves);
        }

        Dfs(root1, leaves1);
        Dfs(root2, leaves2);

        return leaves1.SequenceEqual(leaves2);
    }
}
