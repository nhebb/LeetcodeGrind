using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1382. Balance a Binary Search Tree
public class P1382
{
    public TreeNode BalanceBST(TreeNode root)
    {
        var nodeList = new List<TreeNode>();
        BuildNodeList(root);

        foreach (var node in nodeList)
        {
            node.left = null;
            node.right = null;
        }

        void BuildNodeList(TreeNode node)
        {
            if (node == null) return;

            BuildNodeList(node.left);
            nodeList.Add(node);
            BuildNodeList(node.right);
        }

        TreeNode BuildBst(int idx1, int idx2)
        {
            if (idx2 < idx1) return null;

            var mid = idx1 + (idx2 - idx1) / 2;

            var node = nodeList[mid];
            node.left = BuildBst(idx1, mid - 1);
            node.right = BuildBst(mid + 1, idx2);

            return node;
        }

        return BuildBst(0, nodeList.Count - 1);
    }
}
