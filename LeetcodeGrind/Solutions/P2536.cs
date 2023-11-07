namespace LeetcodeGrind.Solutions;

// 2536. Increment Submatrices by One
public class P2536
{
    public int[][] RangeAddQueries(int n, int[][] queries)
    {
        var ans = new int[n][];
        for (int i = 0; i < n; i++)
            ans[i] = new int[n];

        foreach (var query in queries)
        {
            for (int r = query[0]; r <= query[2]; r++)
            {
                for (int c = query[1]; c <= query[3]; c++)
                {
                    ans[r][c] += 1;
                }
            }
        }

        return ans;
    }
}
