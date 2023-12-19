namespace LeetcodeGrind.Solutions;

// 1496. Path Crossing
public class P1496
{
    public bool IsPathCrossing(string path)
    {
        var hs = new HashSet<(int, int)>();

        var x = 0;
        var y = 0;
        hs.Add((x, y));

        foreach (var dir in path)
        {
            if (dir == 'N')
                y++;
            else if (dir == 'S')
                y--;
            else if (dir == 'E')
                x++;
            else // 'W'
                x--;

            if (!hs.Add((x, y)))
                return true;
        }

        return false;
    }
}
