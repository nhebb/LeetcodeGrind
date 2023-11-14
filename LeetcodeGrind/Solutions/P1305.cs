using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1305. All Elements in Two Binary Search Trees
public class P1305
{
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
    {
        void Dfs(TreeNode node, List<int> list)
        {
            if (node.left != null)
                Dfs(node.left, list);
            list.Add(node.val);
            if (node.right != null)
                Dfs(node.right, list);
        }

        var list1 = new List<int>();
        var list2 = new List<int>();

        if (root1 != null)
            Dfs(root1, list1);
        if (root2 != null)
            Dfs(root2, list2);

        var ans = new List<int>(list1.Count + list2.Count);

        int i = 0;
        int j = 0;
        while (i < list1.Count && j < list2.Count)
        {
            if (list1[i] < list2[j])
            {
                ans.Add(list1[i]);
                i++;
            }
            else
            {
                ans.Add(list2[j]);
                j++;
            }
        }

        while (i < list1.Count)
        {
            ans.Add(list1[i]);
            i++;
        }

        while (j < list2.Count)
        {
            ans.Add(list2[j]);
            j++;
        }

        return ans;
    }
}
