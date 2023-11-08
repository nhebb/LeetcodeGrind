namespace LeetcodeGrind.Solutions;

// 36. Valid Sudoku
public class P0036
{
    public bool IsValidSudoku(char[][] board)
    {
        var hsRow = new HashSet<char>();
        HashSet<char>[] hsCol = new HashSet<char>[9];
        HashSet<char>[] hsBlock = new HashSet<char>[9];

        for (int i = 0; i < 9; i++)
        {
            hsCol[i] = new HashSet<char>();
            hsBlock[i] = new HashSet<char>();
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (board[i][j] == '.')
                    continue;

                if (!hsRow.Add(board[i][j]))
                    return false;

                if (!hsCol[j].Add(board[i][j]))
                    return false;

                int b = (j / 3) + (i / 3) * 3;
                if (!hsBlock[b].Add(board[i][j]))
                    return false;
            }
            hsRow.Clear();
        }
        return true;
    }
}
