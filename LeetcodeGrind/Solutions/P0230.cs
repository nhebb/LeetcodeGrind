using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 230. Kth Smallest Element in a BST
public class P0230
{
    // Priority Queue
    public int KthSmallest(TreeNode root, int k)
    {
        var pq = new PriorityQueue<int, int>();

        void Dfs(TreeNode node)
        {
            if (node == null)
                return;

            pq.Enqueue(node.val, node.val);
            Dfs(node.left);
            Dfs(node.right);
        }

        Dfs(root);

        while (k > 1)
        {
            _ = pq.Dequeue();
            k--;
        }
        return pq.Dequeue();
    }

    // List - faster
    public int KthSmallest2(TreeNode root, int k)
    {
        var list = new List<int>();

        void Dfs(TreeNode node)
        {
            if (list.Count >= k)
                return;

            if(node.left != null)
                Dfs(node.left);
    
            list.Add(node.val);

            if (node.right != null)
                Dfs(node.right);
        }

        Dfs(root);

        // Weirdly, this:
        return list.Skip(k - 1).Take(1).First();

        // ... runs faster than this:
        // return list[k - 1];
    }

}
