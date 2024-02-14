namespace LeetcodeGrind.Solutions;

// 169. Majority Element
public class P0169
{
    public int MajorityElement(int[] nums)
    {
        int maj = nums[0];
        int max = 0;
        var d = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!d.ContainsKey(nums[i]))
                d[nums[i]] = 0;

            d[nums[i]]++;

            if (d[nums[i]] > max)
            {
                max = d[nums[i]];
                maj = nums[i];
            }
        }

        return maj;
    }

    public int MajorityElementLINQ(int[] nums)
    {
        return nums.GroupBy(x => x)
                   .OrderByDescending(g => g.Count())
                   .First()
                   .Key;
    }
}
