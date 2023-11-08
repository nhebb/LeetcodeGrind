namespace LeetcodeGrind.Solutions;

// 2176. Count Equal and Divisible Pairs in an Array
public class P2176
{
    public int CountPairs(int[] nums, int k)
    {
        var count = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j] && (i * j) % k == 0)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
