using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 701. Insert into a Binary Search Tree
public class P0701
{
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root == null)
            return new TreeNode(val);
        else if (val < root.val)
            root.left = InsertIntoBST(root.left, val);
        else
            root.right = InsertIntoBST(root.right, val);

        return root;
    }
}
