using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Intervals;

// 352. Data Stream as Disjoint Intervals
public class SummaryRanges
{
    private HashSet<int> hs;

    public SummaryRanges()
    {
        hs = new HashSet<int>();
    }

    public void AddNum(int value)
    {
        hs.Add(value);
    }

    public int[][] GetIntervals()
    {
        var nums = hs.OrderBy(x => x).ToList();
        var ans = new List<int[]>();

        for (int i = 0; i < nums.Count; i++)
        {
            var firstVal = nums[i];
            var lastVal = firstVal;
            int j = i + 1;
            while (j < nums.Count && nums[j] == lastVal + 1)
            {
                lastVal = nums[j];
                j++;
            }
            ans.Add(new int[] { firstVal, lastVal });
            i = j - 1;
        }

        return ans.ToArray();
    }
}

public class SummaryRanges2
{
    private List<int> list;

    public SummaryRanges2()
    {
        list = new List<int>();
    }

    public void AddNum(int value)
    {
        list.Add(value);
    }

    public int[][] GetIntervals()
    {
        var nums = list.OrderBy(x => x).ToList();
        var ans = new List<int[]>();

        for (int i = 0; i < nums.Count; i++)
        {
            var firstVal = nums[i];
            var lastVal = firstVal;
            int j = i + 1;
            while (j < nums.Count && nums[j] == lastVal + 1)
            {
                lastVal = nums[j];
                j++;
            }
            ans.Add(new int[] { firstVal, lastVal });
            i = j - 1;
        }

        return ans.ToArray();
    }
}