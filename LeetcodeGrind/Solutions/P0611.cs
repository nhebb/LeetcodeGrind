namespace LeetcodeGrind.Solutions;

// 611. Valid Triangle Number
public class P0611
{
    // Brute force
    public int TriangleNumber(int[] nums)
    {
        Array.Sort(nums);
        var count = 0;

        for (int i = 0; i < nums.Length - 2; i++)
        {
            for (int j = i + 1; j < nums.Length - 1; j++)
            {
                for (int k = j + 1; k < nums.Length; k++)
                {
                    if (nums[i] + nums[j] > nums[k])
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }

    // Two pointer
    public int TriangleNumber2(int[] nums)
    {
        Array.Sort(nums);
        var count = 0;

        // Any two sides of a triangle, added together, must
        // be greater than the third side.
        for (int c = nums.Length - 1; c > 1; c--)
        {
            // Have two pointers in the inner loop to find
            // the range of values for a and b that satisfy
            // the a + b > c requirement.
            for (int a = 0, b = c - 1; a < b;)
            {
                if (nums[a] + nums[b] > nums[c])
                {
                    count += b - a;
                    b--;
                }
                else
                {
                    a++;
                }
            }
        }

        return count;
    }
}

