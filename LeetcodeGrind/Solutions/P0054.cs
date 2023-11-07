namespace LeetcodeGrind.Solutions;

// 54. Spiral Matrix
public class P0054
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var spiral = new List<int>();
        var firstRow = 0;
        var firstCol = 0;
        var lastRow = matrix.Length - 1;
        var lastCol = matrix[0].Length - 1;

        while (firstRow < lastRow && firstCol < lastCol)
        {
            // top row
            for (int c = firstCol; c <= lastCol; c++)
            {
                spiral.Add(matrix[firstRow][c]);
            }

            // right column
            for (int r = firstRow + 1; r < lastRow; r++)
            {
                spiral.Add(matrix[r][lastCol]);
            }

            // bottom row
            for (int c = lastCol; c >= firstCol; c--)
            {
                spiral.Add(matrix[lastRow][c]);
            }

            // left column
            for (int r = lastRow - 1; r > firstRow; r--)
            {
                spiral.Add(matrix[r][firstCol]);
            }

            firstRow++;
            lastRow--;
            firstCol++;
            lastCol--;

            if (firstRow == lastRow || firstCol == lastCol) { break; }
        }

        if (firstRow == lastRow && firstCol == lastCol)
        {
            spiral.Add(matrix[firstRow][firstCol]);
        }
        else if (firstRow == lastRow)
        {
            for (int c = firstCol; c <= lastCol; c++)
                spiral.Add(matrix[firstRow][c]);
        }
        else if (firstCol == lastCol)
        {
            for (int r = firstRow; r <= lastRow; r++)
                spiral.Add(matrix[r][firstCol]);
        }

        return spiral;
    }
}
