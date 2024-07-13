using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 987. Vertical Order Traversal of a Binary Tree
public class P0987
{
    private struct RowVal
    {
        public int Row;
        public int Val;
        public RowVal(int row, int val)
        {
            Row = row;
            Val = val;
        }
    }

    public IList<IList<int>> VerticalTraversal(TreeNode root)
    {
        var result = new List<IList<int>>();
        var d = new SortedDictionary<int, List<RowVal>>();
        d[0] = new List<RowVal>();
        d[0].Add(new RowVal(0, root.val));

        VerticalTraversalRecurse(root.left, 1, -1, d);
        VerticalTraversalRecurse(root.right, 1, 1, d);

        foreach (var kvp in d)
        {
            result.Add(kvp.Value.OrderBy(x => x.Row)
                                .ThenBy(x => x.Val)
                                .Select(x => x.Val)
                                .ToList());
        }

        return result;
    }

    private static void VerticalTraversalRecurse(TreeNode node, int row, int col,
        SortedDictionary<int, List<RowVal>> d)
    {
        if (node == null)
            return;

        if (!d.ContainsKey(col))
            d[col] = new List<RowVal>();

        d[col].Add(new RowVal(row, node.val));

        VerticalTraversalRecurse(node.left, row + 1, col - 1, d);
        VerticalTraversalRecurse(node.right, row + 1, col + 1, d);
    }
}
