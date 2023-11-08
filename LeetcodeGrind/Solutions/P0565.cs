namespace LeetcodeGrind.Solutions;

// 565. Array Nesting
public class P0565
{
    public int ArrayNesting(int[] nums)
    {
        var hs = new HashSet<int>();
        var maxCount = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            var val = nums[i];
            int count = 0;

            while (hs.Add(val))
            {
                count++;
                i = val;
                val = nums[i];
            }
            if (count > maxCount)
                maxCount = count;
        }
        return maxCount;
    }
}
