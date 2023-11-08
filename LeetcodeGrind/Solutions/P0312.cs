namespace LeetcodeGrind.Solutions;

// 312. Burst Balloons
public class P0312
{
    public int MaxCoins(int[] nums)
    {
        var burst = new bool[nums.Length];
        var burstCount = 0;

        int GetLeftNum(int i)
        {
            while (i >= 0)
            {
                if (!burst[i])
                    return nums[i];
                i--;
            }
            return 1;
        }
        int GetRightNum(int i)
        {
            while (i < nums.Length)
            {
                if (!burst[i])
                    return nums[i];
                i++;
            }
            return 1;
        }

        var coins = 0;

        while (burstCount < nums.Length)
        {
            var maxCoins = 0;
            var maxIndex = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (burst[i])
                    continue;

                var curCoins = nums[i] * GetLeftNum(i - 1) * GetRightNum(i + 1);
                if (curCoins > maxCoins)
                {
                    maxCoins = curCoins;
                    maxIndex = i;
                }
            }
            coins += maxCoins;
            burst[maxIndex] = true;
            burstCount++;
        }

        return coins;
    }
}
