namespace LeetcodeGrind.Solutions;

// 554. Brick Wall
public class P0554
{
    public int LeastBricks(IList<IList<int>> wall)
    {
        var lengthCounts = new Dictionary<int, int>();
        foreach (var row in wall)
        {
            var len = 0;
            for (int i = 0; i < row.Count - 1; i++)
            {
                len += row[i];
                if (!lengthCounts.TryAdd(len, 1))
                    lengthCounts[len]++;
            }
        }

        var mostEdges = 0;
        foreach (var kvp in lengthCounts)
            mostEdges = Math.Max(mostEdges, kvp.Value);

        return wall.Count - mostEdges;
    }
}
