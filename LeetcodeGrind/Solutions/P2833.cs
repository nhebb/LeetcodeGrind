using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2833. Furthest Point From Origin
public class P2833
{
    public int FurthestDistanceFromOrigin(string moves)
    {
        var distance = 0;
        var blanks = 0;

        foreach (var c in moves)
        {
            if (c == 'L')
                distance--;
            else if (c == 'R')
                distance++;
            else
                blanks++;
        }

        if (distance < 0)
            distance = -distance;

        return distance + blanks;
    }
}
