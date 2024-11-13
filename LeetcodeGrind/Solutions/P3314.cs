namespace LeetcodeGrind.Solutions;

// 3314. Construct the Minimum Bitwise Array I
public class P3314
{
    public int[] MinBitwiseArray(IList<int> nums)
    {
        var result = new int[nums.Count];

        for (int i = 0; i < nums.Count; i++)
        {
            result[i] = -1;

            for (int j = 0; j < nums[i]; j++)
            {
                if ((j | (j + 1)) == nums[i])
                {
                    result[i] = j;
                    break;
                }
            }

        }

        return result;
    }
}
