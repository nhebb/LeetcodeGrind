using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2960. Count Tested Devices After Test Operations
public class P2960
{
    public int CountTestedDevices(int[] batteryPercentages)
    {
        var tested = 0;
        var decrease = 0;

        for (int i = 0; i < batteryPercentages.Length; i++)
        {
            batteryPercentages[i] = Math.Max(0, batteryPercentages[i] - decrease);
            if (batteryPercentages[i] > 0)
            {
                tested++;
                decrease++;
            }
        }

        return tested;
    }
}

