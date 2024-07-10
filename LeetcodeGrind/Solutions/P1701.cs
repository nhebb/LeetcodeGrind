namespace LeetcodeGrind.Solutions;

// 1701. Average Waiting Time
public class P1701
{
    public double AverageWaitingTime(int[][] customers)
    {
        var available = new int[customers.Length];
        var wait = new double[customers.Length];

        available[0] = customers[0][0];
        wait[0] = customers[0][1];

        // [[1,2],[2,5],[4,3]]
        for (int i = 1; i < customers.Length; i++)
        {
            available[i] = Math.Max(available[i - 1] + customers[i - 1][1], customers[i][0]);
            wait[i] = available[i] + customers[i][1] - customers[i][0];
        }

        return wait.Sum() / customers.Length;
    }
}
