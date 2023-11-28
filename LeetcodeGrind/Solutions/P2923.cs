namespace LeetcodeGrind.Solutions;

// 2923. Find Champion I
public class P2923
{
    public int FindChampion(int[][] grid)
    {
        var hs = Enumerable.Range(0, grid.Length).ToHashSet();
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                    hs.Remove(j);
            }
        }

        return hs.First();
    }
}
