using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1026. Maximum Difference Between Node and Ancestor
public class P1026
{
    public int MaxAncestorDiff(TreeNode root)
    {
        var maxDiff = 0;

        var q = new Queue<(TreeNode node, int min, int max)>();
        q.Enqueue((root, root.val, root.val));

        while (q.Count > 0)
        {
            var count = q.Count;

            for (int i = 0; i < count; i++)
            {
                var item = q.Dequeue();
                var node = item.node;
                var min = item.min;
                var max = item.max;

                var valMinDiff = Math.Abs(node.val - min);
                var valMaxDiff = Math.Abs(max - node.val);
                maxDiff = Math.Max(maxDiff, Math.Max(valMinDiff, valMaxDiff));

                var curMin = Math.Min(min, node.val);
                var curMax = Math.Max(max, node.val);

                if (node.left != null)
                {
                    q.Enqueue((node.left, curMin, curMax));
                }
                if (node.right != null)
                {
                    q.Enqueue((node.right, curMin, curMax));
                }
            }
        }

        return maxDiff;
    }


    public int MaxAncestorDiffRecursion(TreeNode root)
    {
        if (root is null)
            return 0;

        var maxDiff = 0;

        void Dfs(TreeNode node, int min, int max)
        {
            var valMinDiff = Math.Abs(node.val - min);
            var valMaxDiff = Math.Abs(max - node.val);
            maxDiff = Math.Max(maxDiff, Math.Max(valMinDiff, valMaxDiff));

            var curMin = Math.Min(min, node.val);
            var curMax = Math.Max(max, node.val);

            if (node.left != null)
            {
                Dfs(node.left, curMin, curMax);
            }
            if (node.right != null)
            {
                Dfs(node.right, curMin, curMax);
            }
        }

        Dfs(root, root.val, root.val);
        return maxDiff;
    }
}
