namespace LeetcodeGrind.Solutions;

// 52. N-Queens II
public class P0052
{
    public int TotalNQueens(int n)
    {
        var total = 0;
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
                total++;
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

        return total;
    }
}
