namespace LeetcodeGrind.Solutions;

// 85. Maximal Rectangle
public class P0085
{
    public int MaximalRectangle(char[][] matrix)
    {
        for (int r = 0; r < matrix.Length; r++)
        {
            for (int c = 1; c < matrix[r].Length; c++)
            {
                if (matrix[r][c] == '1')
                {
                    var val = matrix[r][c - 1] - '0' + 1;
                    matrix[r][c] = (char)('0' + val);
                }
            }
        }

        var max = matrix[0].Select(x => x - '0').Max();

        for (int c = 0; c < matrix[0].Length; c++)
        {
            for (int r = 1; r < matrix.Length; r++)
            {
                if (matrix[r][c] != '0')
                {
                    // 11111        12345
                    // 11111    =>  12345
                    // 00111        00123

                    var val = Math.Min(matrix[r][c] - '0' , matrix[r - 1][c] - '0');
                    max = Math.Max(max, val);
                    matrix[r][c] = (char)('0' + val);
                }
            }
        }

        return max;
    }
}
