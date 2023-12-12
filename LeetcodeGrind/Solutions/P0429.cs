using LeetcodeGrind.NAryTree;

namespace LeetcodeGrind.Solutions;

// 429. N-ary Tree Level Order Traversal
public class P0429
{
    public IList<IList<int>> LevelOrder(Node root)
    {
        var res = new List<IList<int>>();

        void Dfs(Node node, int level)
        {
            if (node == null)
            {
                return;
            }

            if (res.Count == level)
            {
                res.Add(new List<int>());
            }
            res[level].Add(node.val);

            foreach (var child in node.children)
            {
                Dfs(child, level + 1);
            }
        }

        Dfs(root, 0);

        return res;
    }
}
