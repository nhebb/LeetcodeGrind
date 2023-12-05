namespace LeetcodeGrind.Solutions;

// 1025. Divisor Game
public class P1025
{
    public bool DivisorGame(int n)
    {
        // 0 < x < n and n % x == 0
        // Replacing the number n on the chalkboard with n - x.
        var count = 0;
        var i = 1;

        while (i < n)
        {
            var x = i;
            while (n % x == 0)
            {
                count++;
                n = n - x;

                if (i >= n)
                {
                    break;
                }
            }
            i++;
        }

        return count % 2 == 1;
    }
}
