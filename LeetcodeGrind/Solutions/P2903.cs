namespace LeetcodeGrind.Solutions;

// 2903. Find Indices With Index and Value Difference I
public class P2903
{
    public int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
    {
        for (int i = 0; i < nums.Length - indexDifference; i++)
        {
            for (int j = i + indexDifference; j < nums.Length; j++)
            {
                if (Math.Abs(nums[i] - nums[j]) >= valueDifference)
                {
                    return new int[] { i, j };
                }
            }
        }

        return new int[] { -1, -1 };
    }
}
