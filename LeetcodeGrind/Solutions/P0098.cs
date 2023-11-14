using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 98. Validate Binary Search Tree
public class P0098
{
    public bool IsValidBST(TreeNode root)
    {
        if (root == null)
            return true;

        var nums = new List<int>();

        void DFS(TreeNode node)
        {
            if (node.left != null)
                DFS(node.left);

            nums.Add(node.val);

            if (node.right != null)
                DFS(node.right);
        }

        DFS(root);

        for (int i = 1; i < nums.Count; i++)
        {
            if (nums[i - 1] >= nums[i])
                return false;
        }

        return true;
    }
}
