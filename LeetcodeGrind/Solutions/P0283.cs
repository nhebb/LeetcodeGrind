namespace LeetcodeGrind.Solutions;

// 283. Move Zeroes
public class P0283
{
    public void MoveZeroes(int[] nums)
    {
        int lastIndex = nums.Length - 1;
        while (lastIndex >= 0 && nums[lastIndex] == 0)
        {
            lastIndex--;
        }

        for (int i = lastIndex - 1; i >= 0; i--)
        {
            if (nums[i] == 0)
            {
                for (int j = i; j < lastIndex; j++)
                {
                    nums[j] = nums[j + 1];
                }
                nums[lastIndex] = 0;
                lastIndex--;
            }
        }
    }
}
