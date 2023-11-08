namespace LeetcodeGrind.Solutions;

// 283. Move Zeroes - two solutions
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

    public void MoveZeroes2(int[] nums)
    {
        var offset = 0;
        var firstZeroIndex = nums.Length;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                offset++;
            else if (offset > 0)
            {
                nums[i - offset] = nums[i];
                firstZeroIndex = i - offset + 1;
            }
        }
        for (int i = firstZeroIndex; i < nums.Length; i++)
        {
            nums[i] = 0;
        }
    }
}
