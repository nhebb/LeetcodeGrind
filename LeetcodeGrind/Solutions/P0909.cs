namespace LeetcodeGrind.Solutions;

//909. Snakes and Ladders
public class P0909
{
    public int SnakesAndLadders(int[][] board)
    {
        int n = board.Length;
        Array.Reverse(board);

        var visited = new bool[n * n + 1];
        var queue = new Queue<(int position, int moves)>();
        queue.Enqueue((1, 0));

        // local expression body members to map position to
        // 0-based row and column indices
        int GetRow(int pos) => (pos - 1) / n;

        int GetCol(int pos, bool even) => even
            ? (pos - 1) % n             // left to right index
            : n - 1 - ((pos - 1) % n);  // right to left index

        while (queue.Any())
        {
            var curr = queue.Dequeue();
            for (int i = 1; i <= 6; i++)
            {
                int next = curr.position + i;
                var r = GetRow(next);
                var c = GetCol(next, r % 2 == 0);

                if (board[r][c] != -1)
                    next = board[r][c];

                if (next == n * n)
                    return curr.moves + 1;

                if (!visited[next])
                {
                    visited[next] = true;
                    queue.Enqueue((next, curr.moves + 1));
                }
            }
        }
        return -1;
    }
}
