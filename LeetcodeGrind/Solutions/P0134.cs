namespace LeetcodeGrind.Solutions;

// 134. Gas Station
public class P0134
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        // Run a suffix sum on the net difference between
        // gas and cost. The index where the suffix is
        // maximized indicates the inflection point
        var suffixSum = new int[gas.Length];
        suffixSum[^1] = gas[^1] - cost[^1];
        var max = suffixSum[^1];
        var maxIndex = gas.Length - 1;
        for (int i = gas.Length - 2; i >= 0; i--)
        {
            suffixSum[i] = suffixSum[i + 1] + gas[i] - cost[i];
            if (suffixSum[i] >= max)
            {
                max = suffixSum[i];
                maxIndex = i;
            }
        }

        // If the total cost is greater than the total
        // gas available, solution isn't possible
        if (suffixSum[0] < 0)
            return -1;

        return maxIndex;
    }
}
