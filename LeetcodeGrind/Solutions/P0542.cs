namespace LeetcodeGrind.Solutions;

// 542. 01 Matrix
public class P0542
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        var rows = mat.Length;
        var cols = mat[0].Length;

        var ans = new int[rows][];
        for (int r = 0; r < rows; r++)
        {
            ans[r] = new int[cols];
        }

        // Initialize ans matrix with 0's for 0 values in mat.
        // Set 1 values in mat to int.MaxValue in ans for comparison
        // when doing BFS.
        var q = new Queue<(int row, int col)>();
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (mat[r][c] == 0)
                {
                    ans[r][c] = 0;
                    q.Enqueue((r, c));
                }
                else
                {
                    ans[r][c] = int.MaxValue;
                }
            }
        }

        // BFS over matrix. Start with 0 vals and check neighboring cells.
        // If the new distance is less than the existing val in ans, then
        // update the ans cell value and enqueue the cell.
        while (q.Count > 0)
        {
            var count = q.Count;
            for (int i = 0; i < q.Count; i++)
            {
                var cell = q.Dequeue();
                var r = cell.row;
                var c = cell.col;
                var dist = ans[r][c] + 1;

                // top neighbor
                if (r > 0 && dist < ans[r - 1][c])
                {
                    ans[r - 1][c] = dist;
                    q.Enqueue((r - 1, c));
                }
                // bottom neighbor
                if (r < rows - 1 && dist < ans[r + 1][c])
                {
                    ans[r + 1][c] = dist;
                    q.Enqueue((r + 1, c));
                }
                // left neighbor
                if (c > 0 && dist < ans[r][c - 1])
                {
                    ans[r][c - 1] = dist;
                    q.Enqueue((r, c - 1));
                }
                // right neighbor
                if (c < cols - 1 && dist < ans[r][c + 1])
                {
                    ans[r][c + 1] = dist;
                    q.Enqueue((r, c + 1));
                }
            }
        }

        return ans;
    }
}
