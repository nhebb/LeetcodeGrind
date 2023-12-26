namespace LeetcodeGrind.Solutions;

// 2078. Two Furthest Houses With Different Colors
public class P2078
{
    public int MaxDistance(int[] colors)
    {
        var i = 0;
        var j = colors.Length - 1;
        var max = 0;
        while (i < j && colors[i] == colors[j])
        {
            i++;
        }
        max = j - i;

        i = 0;
        while (i < j && colors[i] == colors[j])
        {
            j--;
        }
        max = Math.Max(max, j - i);

        return max;
    }
}
