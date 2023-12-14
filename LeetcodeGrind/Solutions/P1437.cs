namespace LeetcodeGrind.Solutions;

// 1437. Check If All 1's Are at Least Length K Places Away
public class P1437
{
    public bool KLengthApart(int[] nums, int k)
    {
        var dist = k;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                if (dist < k)
                {
                    return false;
                }
                dist = 0;
            }
            else
            {
                dist++;
            }
        }

        return true;
    }
}
