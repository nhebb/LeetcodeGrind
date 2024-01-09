namespace LeetcodeGrind.Solutions;

// 10035. Maximum Area of Longest Diagonal Rectangle
public class P10035
{
    public int AreaOfMaxDiagonal(int[][] dimensions)
    {
        var maxDiagonal = 0;
        var maxArea = 0;

        for (int i = 0; i < dimensions.Length; i++)
        {
            var diagonal = dimensions[i][0] * dimensions[i][0] +
                           dimensions[i][1] * dimensions[i][1];

            if (diagonal > maxDiagonal)
            {
                maxDiagonal = diagonal;
                maxArea = dimensions[i][0] * dimensions[i][1];
            }
            else if (diagonal == maxDiagonal)
            {
                var area = dimensions[i][0] * dimensions[i][1];
                maxArea = Math.Max(maxArea, area);
            }
        }

        return maxArea;
    }
}
