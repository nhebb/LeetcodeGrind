namespace LeetcodeGrind.Solutions;

// TODO: 218. The Skyline Problem
public class P0218
{
    public IList<IList<int>> GetSkyline(int[][] buildings)
    {
        var ans = new List<IList<int>>();
        if (buildings.Length == 1)
        {
            ans.Add(new List<int>() { buildings[0][0], buildings[0][2] });
            ans.Add(new List<int>() { buildings[0][1], 0 });
        }

        var min = int.MaxValue;
        var max = int.MinValue;

        for (int i = 0; i < buildings.Length; i++)
        {
            if (buildings[i][0] < min)
                min = buildings[i][0];
            if (buildings[i][1] > max)
                max = buildings[i][1];
        }

        var dx = max - min;
        var heights = new int[dx + 1];
        for (int i = 0; i < buildings.Length; i++)
        {
            long l = buildings[i][0] - min;
            long r = buildings[i][1] - min;
            for (long j = l; j < r; j++)
                heights[j] = Math.Max(heights[j], buildings[i][2]);
        }

        for (int i = 0; i < heights.Length; i++)
        {
            if (i == 0 && heights[i] > 0)
                ans.Add(new List<int>() { (int)min, heights[i] });
            else if (i > 0 && heights[i] != heights[i - 1])
                ans.Add(new List<int>() { (int)(i + min), heights[i] });
        }

        return ans;
    }
}
