namespace LeetcodeGrind.Solutions;

// 1848. Minimum Distance to the Target Element
public class P1848
{
    public int GetMinDistance(int[] nums, int target, int start)
    {
        var min = int.MaxValue;

        for (int i = start; i < nums.Length; i++)
        {
            if (nums[i] == target)
            {
                min = Math.Min(min, i - start); 
                break;
            }
        }

        for (int i = start-1; i >=0; i--)
        {
            if (nums[i] == target)
            {
                min = Math.Min(min, start - i);
                break;
            }
        }

        return min;
    }
}
