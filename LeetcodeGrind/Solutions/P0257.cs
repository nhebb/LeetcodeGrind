using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 257. Binary Tree Paths
public class P0257
{
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        var result = new List<string>();

        void BackTrack(TreeNode node, List<int> vals)
        {
            vals.Add(node.val);

            if (node.left != null)
                BackTrack(node.left, vals);

            if (node.right != null)
                BackTrack(node.right, vals);

            if (node.left == null && node.right == null)
                result.Add(string.Join("->", vals));

            vals.RemoveAt(vals.Count - 1);
        }

        BackTrack(root, new List<int>());

        return result;
    }
}
