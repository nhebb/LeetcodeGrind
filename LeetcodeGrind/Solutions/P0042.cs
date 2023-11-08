namespace LeetcodeGrind.Solutions;

// 42. Trapping Rain Water
public class P0042
{
    public int Trap(int[] height)
    {
        var water = 0;
        var maxL = height[0];
        var maxR = height[^1];
        var i = 0;
        var j = height.Length - 1;
        while (i < j)
        {
            if (maxL < maxR)
            {
                i++;
                maxL = Math.Max(maxL, height[i]);
                water += maxL - height[i];
            }
            else
            {
                j--;
                maxR = Math.Max(maxR, height[j]);
                water += maxR - height[j];
            }
        }
        return water;
    }
}
