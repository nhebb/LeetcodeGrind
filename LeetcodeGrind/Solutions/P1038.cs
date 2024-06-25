using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1038. Binary Search Tree to Greater Sum Tree
public class P1038
{
    public TreeNode BstToGst(TreeNode root)
    {
        var values = new List<int>();
        var valToGreaterSumLookup = new Dictionary<int, int>();

        // Read values into a list
        void GetValuesDfs(TreeNode node)
        {
            if (node.left != null)
                GetValuesDfs(node.left);

            values.Add(node.val);

            if (node.right != null)
                GetValuesDfs(node.right);
        }

        // Set Greater Sum values
        void SetGreaterSumDfs(TreeNode node)
        {
            if (node.left != null)
                SetGreaterSumDfs(node.left);

            node.val = valToGreaterSumLookup[node.val];

            if (node.right != null)
                SetGreaterSumDfs(node.right);

        }

        GetValuesDfs(root);

        // Calculate postfix sum
        var sum = 0;
        for (int i = values.Count - 1; i >= 0; i--)
        {
            sum += values[i];
            valToGreaterSumLookup[values[i]] = sum;
        }

        SetGreaterSumDfs(root);

        return root;
    }
}
