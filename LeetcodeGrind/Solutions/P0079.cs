namespace LeetcodeGrind.Solutions;

// 79. Word Search
public class P0079
{
    public bool Exist(char[][] board, string word)
    {
        if (board == null)
            return false;

        if (string.IsNullOrEmpty(word))
            return true;

        var visited = new bool[board.Length, board[0].Length];

        bool BackTrack(int r, int c, int i)
        {
            if (i >= word.Length ||
                r < 0 || r == board.Length ||
                c < 0 || c == board[r].Length)
            {
                return false;
            }

            if (visited[r, c])
                return false;

            visited[r, c] = true;
            var result = false;

            if (board[r][c] == word[i])
            {
                if (i == word.Length - 1)
                {
                    result = true;
                }
                else
                {
                    result = BackTrack(r - 1, c, i + 1) ||
                        BackTrack(r + 1, c, i + 1) ||
                        BackTrack(r, c - 1, i + 1) ||
                        BackTrack(r, c + 1, i + 1);
                }
            }
            visited[r, c] = false;
            return result;
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (BackTrack(i, j, 0))
                    return true;
            }
        }
        return false;
    }
}
