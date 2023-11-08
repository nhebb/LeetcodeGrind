namespace LeetcodeGrind.Solutions;

// 134. Gas Station
public class P0134
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        // Run a postfix sum on the net difference between
        // gas and cost. The index where the postfix is
        // maximized indicates the inflection point
        var postfixSum = new int[gas.Length];
        postfixSum[^1] = gas[^1] - cost[^1];
        var max = postfixSum[^1];
        var maxIndex = gas.Length - 1;
        for (int i = gas.Length - 2; i >= 0; i--)
        {
            postfixSum[i] = postfixSum[i + 1] + gas[i] - cost[i];
            if (postfixSum[i] >= max)
            {
                max = postfixSum[i];
                maxIndex = i;
            }
        }

        // If the total cost is greater than the total
        // gas available, solution isn't possible
        if (postfixSum[0] < 0)
            return -1;

        return maxIndex;
    }
}
