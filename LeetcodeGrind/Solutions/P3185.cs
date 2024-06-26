namespace LeetcodeGrind.Solutions;

// 3185. Count Pairs That Form a Complete Day II
public class P3185
{
    public long CountCompleteDayPairs(int[] hours)
    {
        var hourCounts = new Dictionary<int, int>(24);
        for (int i = 0; i < 24; i++)
        {
            hourCounts[i] = 0;
        }

        for (int i = 0; i < hours.Length; i++)
        {
            hourCounts[hours[i] % 24]++;
        }

        long result = 0;
        for (int i = 0; i <= 12; i++)
        {
            if (i % 12 == 0)
            {
                // Calculate 0 and 12 separately
                var count = hourCounts[i];
                result += ((long)count * (count - 1)) / 2;
            }
            else
            {
                result += (long)hourCounts[i] * hourCounts[24 - i];
            }
        }

        return result;
    }
}
