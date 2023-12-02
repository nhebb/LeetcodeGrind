namespace LeetcodeGrind.Solutions;

// 999. Available Captures for Rook

public class P0999
{
    public int NumRookCaptures(char[][] board)
    {
        var rookRow = -1;
        var rookCol = -1;

        // find rook
        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[r].Length; c++)
            {
                if (board[r][c] == 'R')
                {
                    rookRow = r;
                    rookCol = c;
                    break;
                }
            }
            if (rookRow != -1)
                break;
        }

        var count = 0;
        // up
        for (int r = rookRow - 1, c = rookCol; r >= 0; r--)
        {
            if (board[r][c] == 'B')
            {
                break;
            }
            else if (board[r][c] == 'p')
            {
                count++;
                break;
            }
        }

        // down
        for (int r = rookRow + 1, c = rookCol; r < board.Length; r++)
        {
            if (board[r][c] == 'B')
            {
                break;
            }
            else if (board[r][c] == 'p')
            {
                count++;
                break;
            }
        }

        // left
        for (int r = rookRow, c = rookCol - 1; c >= 0; c--)
        {
            if (board[r][c] == 'B')
            {
                break;
            }
            else if (board[r][c] == 'p')
            {
                count++;
                break;
            }
        }

        // right
        for (int r = rookRow, c = rookCol + 1; c < board[r].Length; c++)
        {
            if (board[r][c] == 'B')
            {
                break;
            }
            else if (board[r][c] == 'p')
            {
                count++;
                break;
            }
        }

        return count;
    }
}
