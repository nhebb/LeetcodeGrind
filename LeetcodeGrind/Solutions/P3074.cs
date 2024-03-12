namespace LeetcodeGrind.Solutions;

// 3074. Apple Redistribution into Boxes
public class P3074
{
    public int MinimumBoxes(int[] apple, int[] capacity)
    {
        Array.Sort(capacity);

        var i = capacity.Length - 1;
        var numApples = apple.Sum();
        var count = 0;

        while (i >= 0 && numApples >0)
        {
            numApples -= capacity[i];
            i--;
            count++;
        }

        return count;
    }
}
