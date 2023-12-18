namespace LeetcodeGrind.Solutions;

// 2965. Find Missing and Repeated Values
public class P2965
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        var d = new Dictionary<int, int>();
        for (int i = 1; i <= grid.Length * grid.Length; i++)
        {
            d[i] = 0;
        }

        for (int r = 0; r < grid.Length; r++)
        {
            for (int c = 0; c < grid[r].Length; c++)
            {
                d[grid[r][c]]++;
            }
        }

        var a = 0;
        var b = 0;

        foreach (var kvp in d)
        {
            if (kvp.Value == 2)
            {
                a = kvp.Key;
            }
            else if (kvp.Value == 0)
            {
                b = kvp.Key;
            }

            if (a != 0 && b != 0)
            {
                break;
            }
        }

        return new int[] { a, b };
    }
}
