namespace LeetcodeGrind.Solutions;

// 1051. Height Checker
public class P1051
{
    public int HeightChecker(int[] heights)
    {
        var expected = new int[heights.Length];
        Array.Copy(heights, expected, heights.Length);
        Array.Sort(expected);

        var count = 0;

        for (int i = 0; i < heights.Length; i++)
        {
            if (heights[i] != expected[i])
                count++;
        }

        return count;
    }
}
