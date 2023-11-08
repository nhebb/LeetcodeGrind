namespace LeetcodeGrind.Solutions;

// 1493. Longest Subarray of 1's After Deleting One Element
public class P1493
{
    public int LongestSubarray(int[] nums)
    {
        var inOnes = false;     // tracks whether we are in consecutive 1's
        var onesCount = 0;      // current 1's count
        var lastOnesCount = 0;  // previous 1's count
        var maxOnes = 0;        // longest pair of subarrays separated by 1 character
        var maxStreak = 0;      // max contiguous subarray of 1's
        var nonOnesCount = 0;   // current non-one characters count
        var lastNonOnesCount = 0;   // previous non-one character count

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                onesCount++;
                if (!inOnes)
                {
                    inOnes = true;
                    if (nonOnesCount == 1)
                    {

                    }
                    lastNonOnesCount = nonOnesCount;
                    nonOnesCount = 0;
                }
            }
            else
            {
                if (inOnes)
                {
                    inOnes = false;
                    maxStreak = Math.Max(maxStreak, onesCount);
                    lastOnesCount = onesCount;
                }
                else
                {

                }
            }
        }

        return Math.Max(maxOnes, maxStreak - 1);
    }
}
