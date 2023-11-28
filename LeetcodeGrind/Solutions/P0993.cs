using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 993. Cousins in Binary Tree
public class P0993
{
    public bool IsCousins(TreeNode root, int x, int y)
    {
        var depthX = 0;
        var parentX = 0;
        var depthY = 0;
        var parentY = 0;

        void Dfs(TreeNode node, int parent, int depth)
        {
            if (node == null)
                return;

            if (node.val == x)
            {
                depthX = depth;
                parentX = parent;
                return;
            }
            else if (node.val == y)
            {
                depthY = depth;
                parentY = parent;
                return;
            }

            Dfs(node.left, node.val, depth + 1);
            Dfs(node.right, node.val, depth + 1);
        }

        Dfs(root, -1, 2);

        return parentX != parentY &&
               depthX == depthY;
    }
}
