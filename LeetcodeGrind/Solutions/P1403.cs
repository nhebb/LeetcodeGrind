namespace LeetcodeGrind.Solutions;

// 1403. Minimum Subsequence in Non-Increasing Order
public class P1403
{
    public IList<int> MinSubsequence(int[] nums)
    {
        Array.Sort(nums, (a, b) => b - a);
        var total = nums.Sum();
        var result = new List<int>();
        var sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            result.Add(nums[i]);
            sum += nums[i];
            total -= nums[i];
            if (sum > total)
            {
                break;
            }
        }

        return result;
    }
}
