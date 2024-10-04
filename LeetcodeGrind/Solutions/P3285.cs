namespace LeetcodeGrind.Solutions;

// 3285. Find Indices of Stable Mountains
public class P3285
{
    public IList<int> StableMountains(int[] height, int threshold)
    {
        var mountains = new List<int>();

        for (int i = 1; i < height.Length; i++)
        {
            if (height[i - 1] > threshold)
            {
                mountains.Add(i);
            }
        }

        return mountains;
    }
}
