namespace LeetcodeGrind.Solutions;

// 119. Pascal's Triangle II
public class P0119
{
    public IList<int> GetRow(int rowIndex)
    {
        // alternate solution using combinatorial math
        // cell val = r! / c!(r - c)!, where r and c
        // are the 0-based row and column indices.
        if (rowIndex == 0)
            return new List<int>() { 1 };

        if (rowIndex == 1)
            return new List<int>() { 1, 1 };

        var triangle = new int[rowIndex + 1][];
        triangle[0] = new int[1] { 1 };
        triangle[1] = new int[2] { 1, 1 };
        for (int row = 2; row <= rowIndex; row++)
        {
            triangle[row] = new int[row + 1];
            triangle[row][0] = 1;
            triangle[row][^1] = 1;

            for (int col = 1; col < triangle[row].Length - 1; col++)
            {
                triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
            }
        }

        return triangle[rowIndex];
    }
}
