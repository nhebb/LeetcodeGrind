using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 105. Construct Binary Tree from Preorder and Inorder Traversal
public class P0105
{
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (preorder.Length == 1) 
            return new TreeNode(preorder[0]);

        var preIndex = 0;

        // minIndex and maxIndex are for the inorder array
        TreeNode Dfs(int minIndex, int maxIndex)
        {
            if (preIndex >= preorder.Length || minIndex > maxIndex)
                return null;

            var val = preorder[preIndex];
            preIndex++;

            var node = new TreeNode(val);
            var mid = Array.IndexOf(inorder, val);

            node.left = Dfs(minIndex, mid - 1);
            node.right = Dfs(mid + 1, maxIndex);

            return node;
        }

        var root = Dfs(0, inorder.Length - 1);

        return root;
    }
}
