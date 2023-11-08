namespace LeetcodeGrind.Solutions;

// 2849. Determine if a Cell Is Reachable at a Given Time
public class P2849
{
    public bool IsReachableAtTime(int sx, int sy, int fx, int fy, int t)
    {
        var dx = Math.Abs(fx - sx);
        var dy = Math.Abs(fy - sy);
        var distance = Math.Max(dx, dy);

        // Edge case where (sx, sy) == (fx, fy)
        if (distance == 0 && t == 1)
            return false;
        else
            return distance <= t;
    }
}
