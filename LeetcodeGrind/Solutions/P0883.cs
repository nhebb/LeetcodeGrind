namespace LeetcodeGrind.Solutions;

// 883. Projection Area of 3D Shapes
public class P0883
{
    public int ProjectionArea(int[][] grid)
    {
        var top = 0;
        var side = 0;
        var front = new int[grid.Length];

        foreach (var row in grid)
        {
            top += row.Count(x => x > 0);
            side += row.Max();
            for (int c = 0; c < grid[0].Length; c++)
            {
                front[c] = Math.Max(row[c], front[c]);
            }
        }

        return top + side + front.Sum();
    }
}
