namespace LeetcodeGrind.Solutions;

// 2389. Longest Subsequence With Limited Sum
public class P2389
{
    public int[] AnswerQueries(int[] nums, int[] queries)
    {
        Array.Sort(nums);
        var ans = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            var count = 0;
            var sum = 0;
            var j = 0;
            while (j < nums.Length)
            {
                sum += nums[j];
                if (sum <= queries[i])
                    count++;
                else
                    break;

                j++;
            }
            ans[i] = count;
        }
        return ans;
    }
}

