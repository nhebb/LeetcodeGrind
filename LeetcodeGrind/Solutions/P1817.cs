namespace LeetcodeGrind.Solutions;

// 1817. Finding the Users Active Minutes
public class P1817
{
    public int[] FindingUsersActiveMinutes(int[][] logs, int k)
    {
        var idMinutesMap = new Dictionary<int, HashSet<int>>();
        foreach (var log in logs)
        {
            if (idMinutesMap.TryGetValue(log[0], out var hs))
            {
                hs.Add(log[1]);
            }
            else
            {
                idMinutesMap[log[0]] = new HashSet<int>();
                idMinutesMap[log[0]].Add(log[1]);
            }
        }

        var ans = new int[k];
        foreach (var kvp in idMinutesMap)
        {
            var numMinutes = kvp.Value.Count;
            if (numMinutes <= k)
                ans[numMinutes - 1]++;
        }

        return ans;
    }
}
