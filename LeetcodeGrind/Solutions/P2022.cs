namespace LeetcodeGrind.Solutions;

// 2022. Convert 1D Array Into 2D Array
public class P2022
{
    public int[][] Construct2DArray(int[] original, int m, int n)
    {
        var ans = new int[m][];
        if (m * n != original.Length)
        {
            ans[0] = Array.Empty<int>();
            return ans;
        }

        for (int i = 0; i < m; i++)
            ans[i] = new int[n];

        for (int i = 0; i < original.Length; i++)
            ans[i / n][i % n] = original[i];

        return ans;
    }
}
