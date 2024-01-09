namespace LeetcodeGrind.Solutions;

// 2379. Minimum Recolors to Get K Consecutive Black Blocks
public class P2379
{
    public int MinimumRecolors(string blocks, int k)
    {
        var count = 0;
        for (int i = 0; i < k; i++)
        {
            if (blocks[i] == 'B')
            {
                count++;
            }
        }

        var maxB = count;
        if (count == k)
        {
            return 0;
        }

        for (int i = 1, j = k; j < blocks.Length; i++, j++)
        {
            if (blocks[i - 1] == 'B')
            {
                count--;
            }
            if (blocks[j] == 'B')
            {
                count++;
                maxB = Math.Max(maxB, count);
            }
        }

        return k - maxB;
    }
}
