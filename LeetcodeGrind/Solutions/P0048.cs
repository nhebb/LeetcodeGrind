namespace LeetcodeGrind.Solutions;

// 48. Rotate Image
public class P0048
{
    public void Rotate(int[][] matrix)
    {
        if (matrix.Length == 1) { return; }

        var offset = 0;
        var first = 0;
        var last = matrix.Length - 1;

        while (first < last)
        {
            while (first + offset < last)
            {
                var temp = matrix[first][first + offset];
                matrix[first][first + offset] = matrix[last - offset][first];
                matrix[last - offset][first] = matrix[last][last - offset];
                matrix[last][last - offset] = matrix[first + offset][last];
                matrix[first + offset][last] = temp;

                offset++;
            }
            offset = 0;
            first++;
            last--;
        }
    }
}
