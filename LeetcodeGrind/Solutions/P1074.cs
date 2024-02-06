namespace LeetcodeGrind.Solutions;

// 1074. Number of Submatrices That Sum to Target
public class P1074
{
    public int NumSubmatrixSumTarget(int[][] matrix, int target)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 1; j < matrix[0].Length; j++)
            {
                matrix[i][j] += matrix[i][j - 1];
            }
        }

        var count = 0;
        var sumValues = new Dictionary<int, int>();

        // Two column loops to repeatedly check columns from outer
        // column start to inner column end.
        for (int c1 = 0; c1 < matrix[0].Length; c1++)
        {
            for (int c2 = c1; c2 < matrix[0].Length; c2++)
            {
                sumValues[0] = 1;
                
                var sum = 0;
                for (int r = 0; r < matrix.Length; r++)
                {
                    var columnValue = c1 > 0 
                        ? matrix[r][c1 - 1] 
                        : 0;
                    sum += matrix[r][c2] - columnValue;

                    var prefixSum = sum - target;

                    if (sumValues.TryGetValue(prefixSum, out var prefixValue))
                        count += prefixValue;

                    if (sumValues.TryGetValue(sum, out var sumValue))
                        sumValues[sum] = sumValue + 1;
                    else
                        sumValues[sum] = 1;
                }

                sumValues.Clear();
            }
        }

        return count;
    }
}
