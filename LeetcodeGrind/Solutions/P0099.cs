using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 99. Recover Binary Search Tree
public class P0099
{
    public void RecoverTree(TreeNode root)
    {
        var list = new List<int>();
        var index = 0;

        void FillList(TreeNode node)
        {
            if (node is null)
                return;

            FillList(node.left);
            list.Add(node.val);
            FillList(node.right);
        }

        void PopulateTree(TreeNode node)
        {
            if (node is null)
                return;

            PopulateTree(node.left);
            node.val = list[index];
            index++;
            PopulateTree(node.right);
        }

        FillList(root);
        list.Sort();
        PopulateTree(root);
    }
}
