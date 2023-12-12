using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1351. Count Negative Numbers in a Sorted Matrix
public class P1351
{
    public int CountNegatives(int[][] grid)
    {
        var count = 0;
        foreach (var row in grid)
        {
            count += row.Count(x => x < 0);
        }
        return count;
    }
}
