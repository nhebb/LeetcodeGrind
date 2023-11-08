namespace LeetcodeGrind.Solutions;

// 74. Search a 2D Matrix
public class P0074
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        bool MatrixBinarySearch(int idx1, int idx2)
        {
            if (idx1 > idx2) return false;

            var mid = idx1 + (idx2 - idx1) / 2;
            var row = mid / cols;
            var col = mid % cols;

            if (idx1 == idx2)
                return matrix[row][col] == target;
            else if (matrix[row][col] == target)
                return true;
            else if (matrix[row][col] > target)
                return MatrixBinarySearch(idx1, mid - 1);
            else
                return MatrixBinarySearch(mid + 1, idx2);
        }

        return MatrixBinarySearch(0, rows * cols - 1);
    }
}
