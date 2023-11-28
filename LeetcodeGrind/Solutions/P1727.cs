namespace LeetcodeGrind.Solutions;

// 1727. Largest Submatrix With Rearrangements
public class P1727
{
    public int LargestSubmatrix(int[][] matrix)
    {
        var numRows = matrix.Length;
        var numCols = matrix[0].Length;

        for (int r = 1; r < numRows; r++)
        {
            for (int c = 0; c < numCols; c++)
            {
                if (matrix[r][c] == 1)
                {
                    // If cell is '1', set it to the above cell's value + 1,
                    // so the column would go 1->2->3 ... for consecutive
                    // cells. This will yield the max consecutive rows
                    // with a '1'.
                    matrix[r][c] = matrix[r - 1][c] + 1;
                }
            }
        }

        var largest = 0;
        for (int r = 0; r < numRows; r++)
        {
            // Sort each row
            Array.Sort(matrix[r]);
            for (int columnCount = 1; columnCount <= numCols; columnCount++)
            {
                // Calculate the largest submatrix =>
                // number of columns * the max consecutive rows
                // that were calculated in the loop above.
                var currentColumn = numCols - columnCount;
                var maxConsecutiveRows = matrix[r][currentColumn];
                largest = Math.Max(largest, columnCount * maxConsecutiveRows);
            }
        }

        return largest;
    }
}
