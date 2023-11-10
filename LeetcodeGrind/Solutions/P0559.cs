using LeetcodeGrind.NAryTree;

namespace LeetcodeGrind.Solutions;

// 559. Maximum Depth of N-ary Tree
// N-ary tree Node is defined in P0590.cs
public class P0559
{
    public int MaxDepth(Node root)
    {
        if (root == null) return 0;

        int Dfs(Node node)
        {
            if (node == null) return 0;
            var max = 0;
            foreach (var child in node.children)
            {
                max = Math.Max(max, Dfs(child));
            }
            return 1 + max;
        }

        return Dfs(root);
    }
}
