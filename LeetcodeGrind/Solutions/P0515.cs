using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 515. Find Largest Value in Each Tree Row
public class P0515
{
    public IList<int> LargestValues(TreeNode root)
    {
        var ans = new List<int>();
        if (root == null)
            return ans;

        void Dfs(TreeNode node, int depth)
        {
            if (ans.Count == depth)
                ans.Add(node.val);
            else if (node.val > ans[depth])
                ans[depth] = node.val;

            if (node.left != null)
                Dfs(node.left, depth + 1);

            if (node.right != null)
                Dfs(node.right, depth + 1);
        }

        Dfs(root, 0);

        return ans;
    }
}
