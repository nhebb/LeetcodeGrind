using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Matrices;

// 304. Range Sum Query 2D - Immutable
public class NumMatrix
{
    private int[][] _prefix;

    public NumMatrix(int[][] matrix)
    {
        _prefix = new int[matrix.Length][];

        for (int r = 0; r < matrix.Length; r++)
        {
            // initialize row
            _prefix[r] = new int[matrix[r].Length];

            // set 1st column
            _prefix[r][0] = matrix[r][0];

            // calc each row prefix
            for (int c = 1; c < matrix[r].Length; c++)
            {
                _prefix[r][c] = _prefix[r][c - 1] + matrix[r][c];
            }
        }

        // calc rectangular prefix
        for (int r = 1; r < matrix.Length; r++)
        {
            for (int c = 0; c < matrix[r].Length; c++)
            {
                _prefix[r][c] = _prefix[r][c] + _prefix[r - 1][c];
            }
        }
    }

    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        return _prefix[row2][col2]
             - GetRectangleSum(row1 - 1, col2)
             - GetRectangleSum(row2, col1 - 1)
             + GetRectangleSum(row1 - 1, col1 - 1);
    }

    private int GetRectangleSum(int r, int c)
    {
        return r < 0 || c < 0
            ? 0
            : _prefix[r][c];
    }
}
