namespace LeetcodeGrind.Solutions;

// 1424. Diagonal Traverse II
public class P1424
{
    public int[] FindDiagonalOrder(IList<IList<int>> nums)
    {
        // This solution is based on the fact that
        // cells in a lower left to upper right diagonal
        // have the same row index + column index sum.
        // We can store the values in a dictionary,
        // with the index sums as the keys.
        var d = new Dictionary<int, List<int>>();
        var maxKey = 0;
        for (int r = 0; r < nums.Count; r++)
        {
            for (int c = 0; c < nums[r].Count; c++)
            {
                if (!d.ContainsKey(r + c))
                    d[r + c] = new List<int>();
                d[r + c].Add(nums[r][c]);

                maxKey = Math.Max(maxKey, r + c);
            }
        }

        var ans = new List<int>();
        for (int key = 0; key <= maxKey; key++)
        {
            // Since the jagged array was iterated
            // from top to bottom, the diagonal
            // values were added in reverse order,
            // so we add each list item to the answer
            // in reverse order.
            if (d.ContainsKey(key))
            {
                for (int i = d[key].Count - 1; i >= 0; i--)
                    ans.Add(d[key][i]);
            }
        }

        return ans.ToArray();
    }
}
