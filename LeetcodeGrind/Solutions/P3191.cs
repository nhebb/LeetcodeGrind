namespace LeetcodeGrind.Solutions;

// 3191. Minimum Operations to Make Binary Array Elements Equal to One I
public class P3191
{
    public int MinOperations(int[] nums)
    {
        var ops = 0;
        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (nums[i] == 0)
            {
                //nums[i] = 1; // not needed
                nums[i + 1] ^= 1;
                nums[i + 2] ^= 1;
                ops++;
            }
        }

        return (nums[^2] == 1 && nums[^1] == 1)
            ? ops
            : -1;
    }
}
