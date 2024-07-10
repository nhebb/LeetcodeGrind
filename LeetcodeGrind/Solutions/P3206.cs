namespace LeetcodeGrind.Solutions;

// 3206. Alternating Groups I
public class P3206
{
    public int NumberOfAlternatingGroups(int[] colors)
    {
        var count = 0;
        if (colors[^1] != colors[0] && colors[0] != colors[1])
        {
            count++;
        }
        if (colors[^2] != colors[^1] && colors[^1] != colors[0])
        {
            count++;
        }

        for (int i = 0; i < colors.Length - 1; i++)
        {
            if (colors[i - 1] != colors[i] && colors[i] != colors[i + 1])
            {
                count++;
            }
        }

        return count;
    }
}
