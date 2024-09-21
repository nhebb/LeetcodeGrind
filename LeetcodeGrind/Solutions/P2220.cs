namespace LeetcodeGrind.Solutions;

// 2220. Minimum Bit Flips to Convert Number
public class P2220
{
    public int MinBitFlips(int start, int goal)
    {
        var val = start ^ goal;
        var count = 0;

        while (val > 0)
        {
            if ((val & 1) == 1)
                count++;

            val >>= 1;
        }
        return count;
    }

    public int MinBitFlips2(int start, int goal)
    {
        var startBits = int.PopCount(start);
        var goalBits = int.PopCount(start ^ goal);
        return Math.Abs(startBits - goalBits);
    }
}
