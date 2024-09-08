using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1367. Linked List in Binary Tree
public class P1367
{
    public bool IsSubPath(ListNode head, TreeNode root)
    {
        var target = head.val;
        var rootNodes = new List<TreeNode>();

        void BuildList(TreeNode node)
        {
            if (node == null) return;
            if (node.val == target)
            {
                rootNodes.Add(node);
            }
            BuildList(node.left);
            BuildList(node.right);
        }

        bool CheckPath(ListNode listNode, TreeNode treeNode)
        {
            if (treeNode == null || listNode.val != treeNode.val)
            {
                return false;
            }

            if (listNode.next == null)
            {
                return true;
            }
            if (treeNode.left == null && treeNode.right == null)
            {
                return false;
            }

            listNode = listNode.next;

            var left = treeNode.left == null
                ? false
                : CheckPath(listNode, treeNode.left);

            var right = treeNode.right == null
                ? false
                : CheckPath(listNode, treeNode.right);

            return left || right;
        }

        BuildList(root);

        foreach (var node in rootNodes)
        {
            if (CheckPath(head, node))
                return true;
        }
        return false;
    }
}
