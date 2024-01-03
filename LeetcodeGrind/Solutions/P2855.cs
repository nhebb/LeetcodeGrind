namespace LeetcodeGrind.Solutions;

// 2855. Minimum Right Shifts to Sort the Array
public class P2855
{
    public int MinimumRightShifts(IList<int> nums)
    {
        var count = 0;
        var shift = -1;

        for (int i = 0; i < nums.Count - 1; i++)
        {
            if (nums[i] > nums[i + 1])
            {
                count++;
                shift = nums.Count - i - 1;
                if (count == 2)
                {
                    return -1;
                }
            }
        }

        if (count == 0)
        {
            return 0;
        }


        if (nums[0] < nums[^1])
            return -1;

        return shift;
    }
}
