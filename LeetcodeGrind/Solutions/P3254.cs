namespace LeetcodeGrind.Solutions;

// 3254. Find the Power of K-Size Subarrays I
public class P3254
{
    public int[] ResultsArray(int[] nums, int k)
    {
        var result = new int[nums.Length - k + 1];

        var consecutives = 1;
        var i = 1;
        while (i < k)
        {
            if (nums[i] == nums[i - 1] + 1)
                consecutives++;
            i++;
        }

        var index = 0;
        result[index] = consecutives == k
            ? nums[k - 1]
            : -1;

        index++;
        i = 1;
        var j = k;
        while (j < nums.Length)
        {
            if (nums[i] == nums[i - 1] + 1)
                consecutives--;
            if (nums[j] == nums[j - 1] + 1)
                consecutives++;

            result[index] = consecutives == k
                ? nums[j]
                : -1;

            i++;
            j++;
            index++;
        }

        return result;
    }
}
