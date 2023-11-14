namespace LeetcodeGrind.Solutions;

// 495. Teemo Attacking

public class P0495
{
    public int FindPoisonedDuration(int[] timeSeries, int duration)
    {
        var time = 0;

        for (int i = 0; i < timeSeries.Length; i++)
        {
            if (i == timeSeries.Length - 1 ||
               timeSeries[i + 1] - timeSeries[i] >= duration)
                time += duration;
            else
                time += timeSeries[i + 1] - timeSeries[i];
        }

        return time;
    }
}
