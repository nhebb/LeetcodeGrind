namespace LeetcodeGrind.Solutions;

// 2643. Row With Maximum Ones
public class P2643
{
    public int[] RowAndMaximumOnes(int[][] mat)
    {
        var result = new int[] { -1, -1 };

        for (int i = 0; i < mat.Length; i++)
        {
            var count = mat[i].Count(x => x == 1);
            if (count > result[1])
            {
                result[0] = i;
                result[1] = count;
            }
        }

        return result;
    }
}
