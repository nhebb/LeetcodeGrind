namespace LeetcodeGrind.Solutions;

// 1275. Find Winner on a Tic Tac Toe Game
public class P1275
{
    public string Tictactoe(int[][] moves)
    {
        var board = new string[3][];
        for (int i = 0; i < 3; i++)
        {
            board[i] = new string[3];
            Array.Fill(board[i], " ");
        }

        var isA = true;
        foreach (var move in moves)
        {
            board[move[0]][move[1]] = isA ? "X" : "O";
            isA = !isA;
        }

        var sets = new string[8];
        sets[0] = board[0][0] + board[0][1] + board[0][2];
        sets[1] = board[1][0] + board[1][1] + board[1][2];
        sets[2] = board[2][0] + board[2][1] + board[2][2];
        sets[3] = board[0][0] + board[1][0] + board[2][0];
        sets[4] = board[0][1] + board[1][1] + board[2][1];
        sets[5] = board[0][2] + board[1][2] + board[2][2];
        sets[6] = board[0][0] + board[1][1] + board[2][2];
        sets[7] = board[0][2] + board[1][1] + board[2][0];

        var pending = false;
        foreach (var set in sets)
        {
            if (set == "XXX")
                return "A";
            else if (set == "OOO")
                return "B";
            else if (set.Contains(' '))
                pending = true;
        }

        return pending ? "Pending" : "Draw";
    }
}