namespace LeetcodeGrind.Solutions;

// 228. Summary Ranges
public class P0228
{
    public IList<string> SummaryRanges(int[] nums)
    {
        var res = new List<string>();

        if (nums.Length == 0)
            return res;
        if (nums.Length == 1)
        {
            res.Add(nums[0].ToString());
            return res;
        }

        Array.Sort(nums);

        var first = nums[0];
        var last = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1] + 1)
            {
                if (first == last)
                    res.Add(first.ToString());
                else
                    res.Add($"{first}->{last}");

                first = nums[i];
            }

            if (i == nums.Length - 1)
            {
                if (first == nums[i])
                    res.Add(first.ToString());
                else
                    res.Add($"{first}->{nums[i]}");
            }

            last = nums[i];
        }

        return res;
    }
}
