namespace LeetcodeGrind;

// 3028. Ant on the Boundary
public class P3028
{
    public int ReturnToBoundaryCount(int[] nums)
    {
        var count = 0;
        var sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (sum == 0)
            {
                count++;
            }
        }

        return count;
    }
}
