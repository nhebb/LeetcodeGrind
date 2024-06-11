namespace LeetcodeGrind.Solutions;

// 3168. Minimum Number of Chairs in a Waiting Room
public class P3168
{
    public int MinimumChairs(string s)
    {
        var count = 0;
        var maxCount = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'E')
            {
                count++;
                maxCount = Math.Max(maxCount, count);
            }
            else
            {
                count--;
            }
        }

        return maxCount;
    }
}
