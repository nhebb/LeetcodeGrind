using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1752. Check if Array Is Sorted and Rotated
public class P1752
{
    public bool Check(int[] nums)
    {
        var rotated = false;
        var sorted = false;


        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < nums[i - 1])
            {
                rotated = true;
                sorted = IsSubArraySorted(nums, 0, i - 1)
                      && IsSubArraySorted(nums, i, nums.Length - 1);
                break;
            }
        }

        return sorted && rotated;
    }

    private bool IsSubArraySorted(int[] nums, int start, int end)
    {
        for (int i = start + 1; i <= end; i++)
        {
            if (nums[i] < nums[i - 1])
                return false;
        }
        return true;
    }

    public bool Check2(int[] nums)
    {
        var rotated = false;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] > nums[i])
            {
                if (rotated)
                {
                    // should only happen once in an iteration
                    return false;
                }
                else
                {
                    if (nums[0] < nums[^1])
                    {
                        // if rotated, first should be >= last
                        return false;
                    }
                    rotated = true;
                }
            }
        }

        return true;
    }

}
