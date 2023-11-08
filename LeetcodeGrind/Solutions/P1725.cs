namespace LeetcodeGrind.Solutions;

// 1725. Number Of Rectangles That Can Form The Largest Square
public class P1725
{
    public int CountGoodRectangles(int[][] rectangles)
    {
        var max = 0;
        foreach (var rect in rectangles)
            max = Math.Max(max, Math.Min(rect[0], rect[1]));

        var count = 0;
        foreach (var rect in rectangles)
            if (Math.Min(rect[0], rect[1]) == max)
                count++;

        return count;
    }
}
