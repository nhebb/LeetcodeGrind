namespace LeetcodeGrind.Solutions;

// 2974. Minimum Number Game
public class P2974
{
    public int[] NumberGame(int[] nums)
    {
        Array.Sort(nums);

        var arr = new int[nums.Length];
        for (int i = 0; i < nums.Length - 1; i += 2)
        {
            arr[i] = nums[i + 1];
            arr[i + 1] = nums[i];
        }

        return arr;
    }
}
