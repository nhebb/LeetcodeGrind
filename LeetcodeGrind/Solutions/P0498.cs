namespace LeetcodeGrind.Solutions;

// 498. Diagonal Traverse
public class P0498
{
    public int[] FindDiagonalOrder(int[][] mat)
    {
        var ans = new List<int>(mat.Length * mat[0].Length);
        var bottom = mat.Length - 1;
        var right = mat[0].Length - 1;
        var startPos = new int[bottom + right + 1, 2];

        for (int i = 0; i < startPos.GetLength(0); i++)
        {
            startPos[i, 0] = i % 2 == 0
                ? Math.Min(i, bottom)
                : Math.Max(0, i - right);
            startPos[i, 1] = i % 2 == 0
                ? Math.Max(0, i - bottom)
                : Math.Min(i, right);
        }

        for (int i = 0; i < startPos.GetLength(0); i++)
        {
            var r = startPos[i, 0];
            var c = startPos[i, 1];
            if (i % 2 == 0)
                while (r >= 0 && c <= right)
                    ans.Add(mat[r--][c++]);
            else
                while (r <= bottom && c >= 0)
                    ans.Add(mat[r++][c--]);

        }

        return ans.ToArray();
    }
}
