namespace LeetcodeGrind.Solutions;

// 2225. Find Players With Zero or One Losses
public class P2225
{
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        var winners = new HashSet<int>(matches.Length);
        var losers = new Dictionary<int, int>(matches.Length);

        for (int i = 0; i < matches.Length; i++)
        {
            winners.Add(matches[i][0]);

            if (losers.ContainsKey(matches[i][1]))
                losers[matches[i][1]]++;
            else
                losers.Add(matches[i][1], 1);
        }

        var oneLoss = new List<int>();
        foreach (var kvp in losers)
        {
            if (kvp.Value == 1)
            {
                oneLoss.Add(kvp.Key);
            }
            winners.Remove(kvp.Key);
        }
        oneLoss.Sort();

        var zeroLoss = winners.ToList();
        zeroLoss.Sort();

        var result = new List<IList<int>>() { zeroLoss, oneLoss };
        return result;
    }
}
