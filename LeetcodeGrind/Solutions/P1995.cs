namespace LeetcodeGrind.Solutions;

// 1995. Count Special Quadruplets
public class P1995
{
    public int CountQuadruplets(int[] nums)
    {
        var count = 0;

        for (int a = 0; a < nums.Length - 3; a++)
        {
            for (int b = a + 1; b < nums.Length - 2; b++)
            {
                for (int c = b + 1; c < nums.Length - 1; c++)
                {
                    for (int d = c + 1; d < nums.Length; d++)
                    {
                        if (nums[a] + nums[b] + nums[c] == nums[d])
                        {
                            count++;
                        }
                    }
                }
            }
        }

        return count;
    }
}
