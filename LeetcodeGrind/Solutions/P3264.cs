namespace LeetcodeGrind.Solutions;

//3264. Final Array State After K Multiplication Operations I
public class P3264
{
    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        for (int i = 0; i < k; i++)
        {
            var min = nums.Min();
            var index = Array.IndexOf(nums, min);
            nums[index] *= multiplier;
        }

        return nums;
    }
}
