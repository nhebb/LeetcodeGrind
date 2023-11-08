namespace LeetcodeGrind.Solutions;

// 2251. Number of Flowers in Full Bloom
public class P2251
{
    public int[] FullBloomFlowers(int[][] flowers, int[] people)
    {
        var d = new Dictionary<int, int>();

        for (int i = 0; i < people.Length; i++)
        {
            d[people[i]] = 0;
        }

        foreach (var flower in flowers)
        {
            for (int time = flower[0]; time <= flower[1]; time++)
            {
                if (d.ContainsKey(time))
                {
                    d[flower[time]]++;
                }
            }
        }

        var ans = new int[people.Length];
        for (int i = 0; i < ans.Length; i++)
        {
            ans[i] = d[people[i]];
        }

        return ans;
    }
}
