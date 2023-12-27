using System.Text;

namespace LeetcodeGrind.Solutions;

// 1578. Minimum Time to Make Rope Colorful
public class P1578
{
    public int MinCost(string colors, int[] neededTime)
    {
        var groups = new List<IList<int>>();

        var start = 0;
        var end = 1;
        while (end < colors.Length)
        {
            if (colors[end] != colors[start])
            {
                groups.Add(new int[] { start, end - 1 });
                start = end;
            }
            end++;
        }
        groups.Add(new int[] { start, end - 1 });

        var minCost = 0;
        for (int i = 0; i <  groups.Count;i++)
        {
            var sum = 0;
            var max = int.MinValue;
            for (int j = groups[i][0]; j <= groups[i][1]; j++ )
            {
                sum += neededTime[j];
                max = Math.Max(max, neededTime[j]);
            }
            minCost += sum - max;
        }

        return minCost;
    }
}
