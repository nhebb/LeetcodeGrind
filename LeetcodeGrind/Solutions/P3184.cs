namespace LeetcodeGrind.Solutions;

// 3184. Count Pairs That Form a Complete Day I
public class P3184
{
    // Note: This solution is the same as P3185, except
    // this is the Easy version with smaller inputs and 
    // looser constraints.
    public int CountCompleteDayPairs(int[] hours)
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

        var result = 0;
        for (int i = 0; i <= 12; i++)
        {
            if (i % 12 == 0)
            {
                // Calculate 0 and 12 separately
                var count = hourCounts[i];
                result += (count * (count - 1)) / 2;
            }
            else
            {
                result += hourCounts[i] * hourCounts[24 - i];
            }
        }

        return result;
    }
}
