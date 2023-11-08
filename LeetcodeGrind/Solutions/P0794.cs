namespace LeetcodeGrind.Solutions;

// 794. Valid Tic-Tac-Toe State
public class P0794
{
    public bool ValidTicTacToe(string[] board)
    {
        var countX = 0;
        var countO = 0;
        var xRowWins = 0;
        var oRowWins = 0;
        var xColWins = 0;
        var oColWins = 0;

        foreach (var row in board)
        {
            if (row.Length != 3)
                return false;

            if (row == "XXX")
                xRowWins++;
            else if (row == "OOO")
                oRowWins++;

            foreach (var c in row)
            {
                if (c == 'X')
                    countX++;
                else if (c == 'O')
                    countO++;
            }
        }

        if (xRowWins > 1 || oRowWins > 1)
            return false;
        if (xRowWins == 1 && oRowWins == 1)
            return false;

        for (int c = 0; c < 3; c++)
        {
            if (board[0][c] == board[1][c] && board[1][c] == board[2][c])
            {
                if (board[0][c] == 'X')
                    xColWins++;
                else if (board[0][c] == 'O')
                    oColWins++;
            }
        }

        var xDiagWins = 0;
        var oDiagWins = 0;
        if (board[0][0] == board[1][1] && board[1][1] == board[2][2])
        {
            if (board[0][0] == 'X')
                xDiagWins++;
            else if (board[0][0] == 'O')
                oDiagWins++;
        }
        if (board[0][2] == board[1][1] && board[1][1] == board[2][0])
        {
            if (board[0][2] == 'X')
                xDiagWins++;
            else if (board[0][2] == 'O')
                oDiagWins++;
        }

        if (xColWins > 1 || oColWins > 1)
            return false;
        if (xColWins == 1 && oColWins == 1)
            return false;

        if (countO > countX || countX - countO > 1)
            return false;

        if (oColWins + oRowWins + oDiagWins > 0 && countX > countO)
            return false;

        if (countX == countO && (xRowWins + xColWins + xDiagWins > 0))
            return false;

        return true;
    }
}
