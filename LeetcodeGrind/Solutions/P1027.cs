namespace LeetcodeGrind.Solutions;

// 1027. Longest Arithmetic Subsequence
public class P1027
{
    public int LongestArithSeqLength(int[] nums)
    {
        var max = 1;
        var i = 0;
        var j = 1;
        while (j < nums.Length)
        {
            var delta = nums[j] - nums[i];
            while (j < nums.Length && nums[j] - nums[j - 1] == delta)
            {
                j++;
            }
            var len = j - i;
            max = Math.Max(max, len);
            i = j;
            j++;
        }

        return max;
    }
}
