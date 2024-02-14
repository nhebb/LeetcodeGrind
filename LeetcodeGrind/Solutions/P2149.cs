namespace LeetcodeGrind.Solutions;

// 2149. Rearrange Array Elements by Sign
public class P2149
{
    public int[] RearrangeArray(int[] nums)
    {
        var result = new int[nums.Length];
        var neg = 0;
        var pos = 0;
        int i = 0;
        while (i < nums.Length - 1)
        {
            while (nums[pos] < 0)
                pos++;
            while (nums[neg] > 0)
                neg++;

            result[i] = nums[pos];
            result[i + 1] = nums[neg];

            i += 2;
            pos++;
            neg++;
        }
        return result;
    }

    // Simplified logic
    public int[] RearrangeArray2(int[] nums)
    {
        var result = new int[nums.Length];
        var pos = 0;
        var neg = 1;

        for(int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < 0)
            {
                result[neg] = nums[i];
                neg += 2;
            }
            else
            {
                result[pos] = nums[i];
                pos += 2;
            }
        }

        return result;
    }
}
