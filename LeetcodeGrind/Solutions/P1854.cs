namespace LeetcodeGrind.Solutions;

// 1854. Maximum Population Year
public class P1854
{
    public int MaximumPopulation(int[][] logs)
    {
        const int startYear = 1950;
        var population = new int[100];

        for (int i = 0; i < logs.Length; i++)
        {
            for (int j = logs[i][0]; j < logs[i][1]; j++)
            {
                population[j - startYear]++;
            }
        }

        var maxYear = 0;
        var max = 0;
        for (int i = 0; i < population.Length; i++)
        {
            if (population[i] > max)
            {
                maxYear = i + startYear;
                max = population[i];
            }
        }

        return maxYear;
    }
}
