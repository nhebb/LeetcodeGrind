namespace LeetcodeGrind.Solutions;

// 130. Surrounded Regions
public class P0130
{
    public void Solve(char[][] board)
    {
        var rows = board.Length;
        var cols = board[0].Length;

        var connected = new bool[rows][];
        for (int r = 0; r < board.Length; r++)
            connected[r] = new bool[cols];

        void Dfs(int r, int c)
        {
            if (r < 0 || r >= rows) return;
            if (c < 0 || c >= cols) return;
            if (connected[r][c]) return;
            if (board[r][c] == 'X') return;

            connected[r][c] = true;

            Dfs(r - 1, c);
            Dfs(r + 1, c);
            Dfs(r, c - 1);
            Dfs(r, c + 1);
        }

        // Iterate over the edges and Dfs inward to mark squares
        // as connected to an outside (unsurrounded) edge square
        // top row
        for (int c = 0; c < cols; c++)
            if (board[0][c] == 'O')
                Dfs(0, c);

        // bottom row
        for (int c = 0; c < cols; c++)
            if (board[rows - 1][c] == 'O')
                Dfs(rows - 1, c);

        // left edge
        for (int r = 0; r < rows; r++)
            if (board[r][0] == 'O')
                Dfs(r, 0);

        // right edge
        for (int r = 0; r < rows; r++)
            if (board[r][cols - 1] == 'O')
                Dfs(r, cols - 1);

        // Flip any non-connected 'O' squares to 'X'
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                if (board[r][c] == 'O' && !connected[r][c])
                    board[r][c] = 'X';
    }
}

