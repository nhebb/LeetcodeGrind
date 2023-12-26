namespace LeetcodeGrind.Solutions;

// 2133. Check if Every Row and Column Contains All Numbers
public class P2133
{
    public bool CheckValid(int[][] matrix)
    {
        var n = matrix.Length;
        var hasVals = new bool[n];

        // Check rows
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                hasVals[matrix[r][c] - 1] = true;
            }
            if (hasVals.Any(x => x == false))
            {
                return false;
            }
            Array.Fill(hasVals, false);
        }

        // Check columns
        for (int c = 0; c < n; c++)
        {
            for (int r = 0; r < n; r++)
            {
                hasVals[matrix[r][c] - 1] = true;
            }
            if (hasVals.Any(x => x == false))
            {
                return false;
            }
            Array.Fill(hasVals, false);
        }

        return true;
    }
}
