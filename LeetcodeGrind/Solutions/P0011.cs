namespace LeetcodeGrind.Solutions;

// 11. Container With Most Water
public class P0011
{
    public int MaxArea(int[] height)
    {
        var maxArea = 0;
        var x1 = 0;
        var x2 = height.Length - 1;

        while (x1 < x2)
        {
            maxArea = Math.Max(maxArea, Math.Min(height[x1], height[x2]) * (x2 - x1));
            if (height[x1] > height[x2])
            {
                x2--;
            }
            else
            {
                x1++;
            }
        }
        return maxArea;
    }
}
