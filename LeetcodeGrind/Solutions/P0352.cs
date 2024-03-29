namespace LeetcodeGrind.Solutions;

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

// Note: using a List instead of a HashSet ended up with the same performance
public class SummaryRanges2
{
    private List<int> nums;

    public SummaryRanges2()
    {
        nums = new List<int>();
    }

    public void AddNum(int value)
    {
        nums.Add(value);
    }

    public int[][] GetIntervals()
    {
        nums.Sort();
        var ans = new List<int[]>();

        for (int i = 0; i < nums.Count; i++)
        {
            var firstVal = nums[i];
            var lastVal = firstVal;
            int j = i + 1;
            while (j < nums.Count && nums[j] <= lastVal + 1)
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