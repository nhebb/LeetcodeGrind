using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 108. Convert Sorted Array to Binary Search Tree
public class P0108
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return null;

        TreeNode Dfs(int idx1, int idx2)
        {
            if (idx2 < idx1)
                return null;

            var mid = idx1 + (idx2 - idx1) / 2;

            var node = new TreeNode(nums[mid]);
            node.left = Dfs(idx1, mid - 1);
            node.right = Dfs(mid + 1, idx2);

            return node;
        }

        var root = Dfs(0, nums.Length - 1);

        return root;
    }
}
