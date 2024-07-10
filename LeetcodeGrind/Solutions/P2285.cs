namespace LeetcodeGrind.Solutions;

// 2285. Maximum Total Importance of Roads
public class P2285
{
    public long MaximumImportance(int n, int[][] roads)
    {
        long[] counts = new long[n];
        foreach (var road in roads)
        {
            counts[road[0]]++;
            counts[road[1]]++;
        }

        Array.Sort(counts);

        long max = 0;

        for (int i = 0; i < counts.Length; i++)
        {
            max += (i + 1) * counts[i];
        }

        return max;
    }
}

