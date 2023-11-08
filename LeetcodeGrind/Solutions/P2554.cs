namespace LeetcodeGrind.Solutions;

// 2554. Maximum Number of Integers to Choose From a Range I
public class P2554
{
    public int MaxCount(int[] banned, int n, int maxSum)
    {
        var nums = Enumerable.Range(1, n).Except(banned).ToArray();
        var sum = 0;
        var count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (sum + nums[i] <= maxSum)
            {
                sum += nums[i];
                count++;
            }
            else
            {
                break;
            }
        }
        return count;
    }
}
