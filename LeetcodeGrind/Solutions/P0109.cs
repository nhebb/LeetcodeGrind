using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 109. Convert Sorted List to Binary Search Tree
public class P0109
{
    public TreeNode SortedListToBST(ListNode head)
    {
        if (head == null)
            return null;

        var nums = new List<int>();
        while (head != null)
        {
            nums.Add(head.val);
            head = head.next;
        }

        TreeNode CreateTree(int low, int high)
        {
            if (high < low)
                return null;

            var mid = low + (high - low) / 2;
            var node = new TreeNode(nums[mid]);
            node.left = CreateTree(low, mid - 1);
            node.right = CreateTree(mid + 1, high);

            return node;
        }

        return CreateTree(0, nums.Count - 1);
    }
}
