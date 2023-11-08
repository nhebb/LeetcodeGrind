namespace LeetcodeGrind.Solutions;

// 118. Pascal's Triangle
public class P0118
{
    public IList<IList<int>> Generate(int numRows)
    {
        var result = new List<IList<int>>();
        if (numRows < 1) { return result; }

        result.Add(new List<int>() { 1 });
        if (numRows == 1) return result;

        result.Add(new List<int>() { 1, 1 });
        if (numRows == 2) return result;

        for (int r = 2; r < numRows; r++)
        {
            var row = new List<int>(r) { 1 };
            for (int c = 1; c < r; c++)
            {
                row.Add(result[r - 1][c - 1] + result[r - 1][c]);
            }
            row.Add(1);
            result.Add(row);
        }
        return result;
    }
}

