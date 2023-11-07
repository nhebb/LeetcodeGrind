namespace LeetcodeGrind.Solutions;

// 1252. Cells with Odd Values in a Matrix
public class P1252
{
    public int OddCells(int m, int n, int[][] indices)
    {
        var rows = new int[m];
        var cols = new int[n];

        foreach (var index in indices)
        {
            rows[index[0]]++;
            cols[index[1]]++;
        }

        var count = 0;

        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if ((rows[r] + cols[c]) % 2 == 1)
                    count++;
            }
        }

        return count;
    }
}
