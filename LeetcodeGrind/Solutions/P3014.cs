namespace LeetcodeGrind.Solutions;

// 3014. Minimum Number of Pushes to Type Word I
public class P3014
{
    public int MinimumPushes(string word)
    {
        var pushes = 0;
        var len = word.Length;
        var factor = 1;

        while (len > 0)
        {
            if (len <= 8)
            {
                pushes += len * factor;
                break;
            }

            pushes += 8 * factor;
            factor++;
            len -= 8;
        }

        return pushes;
    }
}
