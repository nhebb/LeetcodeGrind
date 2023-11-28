using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 868. Binary Gap
public class P0868
{
    public int BinaryGap(int n)
    {
        var binary = Convert.ToString(n, 2);
        var lastOne = 0;

        // Just in case C#'s Convert.ToString() produce leading 0's
        while (binary[lastOne] == '0')
            lastOne++;

        var maxGap = 0;
        var gap = 0;

        for (int i = lastOne + 1; i < binary.Length; i++)
        {
            if (binary[i] == '1')
            {
                gap = i - lastOne;
                maxGap = Math.Max(gap, maxGap);
                lastOne = i;
            }
        }

        return maxGap;
    }

}
