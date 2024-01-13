namespace LeetcodeGrind.Solutions;

// 2511. Maximum Enemy Forts That Can Be Captured
public class P2511
{
    public int CaptureForts(int[] forts)
    {
        var max = 0;
        var empty = -1;
        var enemy = 0;
        var mine = 1;

        for (int i = 0, j = 0; j < forts.Length; j++)
        {
            if (forts[j] == enemy)
                continue;

            // We are only interested in the spans between
            // our forts and empty forts
            if (forts[i] == empty && forts[j] == mine ||
                forts[j] == empty && forts[i] == mine)
            {
                max = Math.Max(max, j - i - 1);
            }

            i = j;
        }

        return max;
    }
}
