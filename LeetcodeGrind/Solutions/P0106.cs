using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 106. Construct Binary Tree from Inorder and Postorder Traversal
public class P0106
{
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        // Base constraints state that there will be at least 1
        // node, but required for recursive calls.
        if (inorder.Length == 0 && postorder.Length == 0)
            return null;

        // The last node in a post order traversal
        // is the tree's root.
        var root = new TreeNode(postorder[^1]);

        if (inorder.Length == 1)
            return root;

        int rootIndex = Array.IndexOf(inorder, root.val);

        var inorderLeft = inorder.Take(rootIndex).ToArray();
        var postorderLeft = postorder.Take(rootIndex).ToArray();

        var inorderRight = inorder.Skip(rootIndex + 1).ToArray();
        var postorderRight = postorder.Skip(rootIndex).Take(inorderRight.Length).ToArray();

        root.left = BuildTree(inorderLeft, postorderLeft);
        root.right = BuildTree(inorderRight, postorderRight);

        return root;
    }
}
