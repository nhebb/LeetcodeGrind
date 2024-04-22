namespace LeetcodeGrind.Solutions;

// 1992. Find All Groups of Farmland
public class P1992
{
    public int[][] FindFarmland(int[][] land)
    {
        var result = new List<int[]>();

        for (int r1 = 0; r1 < land.Length; r1++)
        {
            for (int c1 = 0; c1 < land[0].Length; c1++)
            {
                if (land[r1][c1] == 0)
                    continue;

                var r2 = r1;
                var c2 = c1;

                while (r2 < land.Length && land[r2][c1] == 1)
                    r2++;

                while (c2 < land[0].Length && land[r1][c2] == 1)
                    c2++;

                result.Add(new int[] { r1, c1, r2 - 1, c2 - 1 });

                for (int r = r1; r < r2; r++)
                {
                    for (int c = c1; c < c2; c++)
                    {
                        land[r][c] = 0;
                    }
                }
            }
        }

        return result.ToArray();
    }
}
