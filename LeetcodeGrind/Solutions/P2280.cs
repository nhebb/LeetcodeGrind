namespace LeetcodeGrind.Solutions;

// 2280. Minimum Lines to Represent a Line Chart
public class P2280
{
    public int MinimumLines(int[][] stockPrices)
    {
        if (stockPrices.Length == 1)
            return 0;

        // Note: After several tests, Array.Sort runs
        //       much faster on LC than OrderBy().
        // var prices = stockPrices.OrderBy(x => x[0])
        //                         .ToArray();

        Array.Sort(stockPrices, (a, b) => a[0].CompareTo(b[0]));

        var count = 1;
        var dx = stockPrices[1][0] - stockPrices[0][0];
        var dy = stockPrices[1][1] - stockPrices[0][1];

        // Note: Has to be decimal. Double will get Wrong Answer.
        decimal lastSlope = dy / (decimal)dx;

        int i = 2;
        while (i < stockPrices.Length)
        {
            dx = stockPrices[i][0] - stockPrices[i - 1][0];
            dy = stockPrices[i][1] - stockPrices[i - 1][1];
            var curSlope = dy / (decimal)dx;

            if (curSlope != lastSlope)
            {
                count++;
                lastSlope = curSlope;
            }

            i++;
        }

        return count;
    }
}
