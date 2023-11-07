namespace LeetcodeGrind.Solutions;

// 2352. Equal Row and Column Pairs
public class P2352
{
    public int EqualPairs(int[][] grid)
    {
        var dictRows = new Dictionary<string, int>();
        for (int r = 0; r < grid.Length; r++)
        {
            var s = string.Join(',', grid[r]);
            if (dictRows.TryGetValue(s, out int value))
                dictRows[s] = value + 1;
            else
                dictRows[s] = 1;
        }

        var dictCols = new Dictionary<string, int>();
        var nums = new List<int>(grid.Length);
        for (int c = 0; c < grid.Length; c++)
        {
            for (int r = 0; r < grid.Length; r++)
            {
                nums.Add(grid[r][c]);
            }

            var s = string.Join(',', nums);
            if (dictCols.TryGetValue(s, out int value))
                dictCols[s] = value + 1;
            else
                dictCols[s] = 1;

            nums.Clear();
        }

        var count = 0;
        foreach (var kvp in dictRows)
        {
            if (dictCols.ContainsKey(kvp.Key))
                count += kvp.Value * dictCols[kvp.Key];
        }

        return count;
    }
}
