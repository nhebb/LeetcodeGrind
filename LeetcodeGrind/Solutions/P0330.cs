namespace LeetcodeGrind.Solutions;

// 330. Patching Array
public class P0330
{
    public int MinPatches(int[] nums, int n)
    {
        var i = 0;
        var patches = 0;
        var targetSum = 1L;

        while (targetSum <= n)
        {
            if (i < nums.Length && nums[i] <= targetSum)
            {
                targetSum += nums[i];
                i++;
            }
            else
            {
                targetSum *= 2;
                patches++;
            }
        }

        return patches;
    }
}
