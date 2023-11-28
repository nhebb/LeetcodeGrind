using System;

namespace LeetcodeGrind.Solutions;

// 2147. Number of Ways to Divide a Long Corridor
public class P2147
{
    public int NumberOfWays(string corridor)
    {
        var seatIndex = new List<int>();
        for (int i = 0; i < corridor.Length; i++)
        {
            if (corridor[i] == 'S')
                seatIndex.Add(i);
        }

        if (seatIndex.Count == 0 || seatIndex.Count % 2 == 1)
        {
            return 0;
        }
        else if (seatIndex.Count == 2)
        {
            return 1;
        }

        const int mod = 1_000_000_007;
        var ans = 1;
        var lastIndex = seatIndex[1];

        for (int i = 2; i < seatIndex.Count; i += 2)
        {
            int span = seatIndex[i] - lastIndex;
            ans = (ans * span) % mod;
            lastIndex = seatIndex[i + 1];
        }

        return ans;
    }
}
