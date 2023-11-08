namespace LeetcodeGrind.Solutions;

// 51. N-Queens
public class P0051
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        var result = new List<IList<string>>(n);

        var board = new char[n][];
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = new char[n];
            Array.Fill(board[i], '.');
        }

        var hsCols = new HashSet<int>();  // col #
        var hsDownDiag = new HashSet<int>(); // r + c
        var hsUpDiag = new HashSet<int>(); // r - c

        void Backtrack(int r)
        {
            if (r == n)
            {
                var currentBoard = new List<string>();
                foreach (var row in board)
                    currentBoard.Add(string.Join("", row));
                result.Add(currentBoard);
                return;
            }

            for (int c = 0; c < board[r].Length; c++)
            {
                if (hsCols.Contains(c) ||
                    hsDownDiag.Contains(r + c) ||
                    hsUpDiag.Contains(r - c))
                    continue;

                hsCols.Add(c);
                hsDownDiag.Add(r + c);
                hsUpDiag.Add(r - c);
                board[r][c] = 'Q';

                Backtrack(r + 1);

                board[r][c] = '.';
                hsCols.Remove(c);
                hsDownDiag.Remove(r + c);
                hsUpDiag.Remove(r - c);
            }
        }

        Backtrack(0);

        return result;
    }
}
