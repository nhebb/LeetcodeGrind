namespace LeetcodeGrind.Solutions;

// 492. Construct the Rectangle
public class P0492
{
    public int[] ConstructRectangle(int area)
    {
        var w = (int)Math.Sqrt(area);
        while (area % w != 0)
            w--;

        return new int[] { area / w, w };
    }
}
