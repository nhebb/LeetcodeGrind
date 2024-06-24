namespace LeetcodeGrind.Solutions;


// 3127. Make a Square with the Same Color
public class P3127
{
    public bool CanMakeSquare(char[][] grid)
    {
        int GetValue(int r, int c)
        {
            return grid[r][c] == 'B' ? 0 : 1;
        }

        for (int r = 0; r < grid.Length - 1; r++)
        {
            for (int c = 0; c < grid[r].Length - 1; c++)
            {
                var sum = GetValue(r, c) + GetValue(r + 1, c)
                        + GetValue(r, c + 1) + GetValue(r + 1, c + 1);

                if (sum != 2)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
