using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 652. Find Duplicate Subtrees
public class P0652
{
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        if (root == null)
            return new List<TreeNode>();

        // 2 hash sets - 1st to find duplicates, and 2nd 
        // to avoid multiple duplicates in result list.
        var hsFound = new HashSet<string>();
        var hsResult = new HashSet<string>();
        var res = new List<TreeNode>();

        // Create "L" & "R" delimted string of node values
        // and check at each node whether same pattern
        // exists in hsFound. If not, attempt to add to
        // result set.
        string Dfs(TreeNode node)
        {
            var cur = $"{node.val}";
            if (node.left != null)
                cur = $"{Dfs(node.left)}L{cur}";
            if (node.right != null)
                cur = $"{cur}R{Dfs(node.right)}";

            if (!hsFound.Add(cur) && hsResult.Add(cur))
                res.Add(node);

            return cur;
        }

        Dfs(root);

        return res;
    }
}
