namespace LeetcodeGrind.Solutions;

// 2563. Count the Number of Fair Pairs
public class P2563
{
    public long CountFairPairs(int[] nums, int lower, int upper)
    {
        Array.Sort(nums);

        long CountPairsBelowValue(int val)
        {
            long count = 0;

            for (int i = 0, j = nums.Length - 1; i < j; i++)
            {
                while (i < j && nums[i] + nums[j] > val)
                {
                    j--;
                }
                count += j - i;
            }

            return count;
        }

        // Count the number of pairs below upper then
        // subtract the number of pairs below lower.
        return CountPairsBelowValue(upper) - CountPairsBelowValue(lower - 1);
    }
}
