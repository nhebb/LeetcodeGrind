namespace LeetcodeGrind.Solutions;

// 1552. Magnetic Force Between Two Balls
public class P1552
{
    public int MaxDistance(int[] position, int m)
    {
        Array.Sort(position);

        var left = 1;
        var right = position[^1] - position[0];
        var result = 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (CanPlace(position, m, mid))
            {
                result = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }

    bool CanPlace(int[] position, int m, int mid)
    {
        var numBalls = 1;
        var prev = position[0];

        for (int i = 1; i < position.Length; i++)
        {
            if (position[i] - prev >= mid)
            {
                prev = position[i];
                numBalls++;
                if (numBalls == m)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
