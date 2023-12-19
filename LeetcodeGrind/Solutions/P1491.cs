namespace LeetcodeGrind.Solutions;

// 1491. Average Salary Excluding the Minimum and Maximum Salary
public class P1491
{
    public double Average(int[] salary)
    {
        var min = int.MaxValue;
        var max = int.MinValue;
        long sum = 0;

        for (int i = 0; i < salary.Length; i++)
        {
            sum += salary[i];
            min = Math.Min(min, salary[i]);
            max = Math.Max(max, salary[i]);
        }

        sum -= min;
        sum -= max;
        double average = sum / (double)(salary.Length - 2);

        return average;
    }
}
