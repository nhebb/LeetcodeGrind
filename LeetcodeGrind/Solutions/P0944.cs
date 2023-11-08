namespace LeetcodeGrind.Solutions;

// 944. Delete Columns to Make Sorted
public class P0944
{
    public int MinDeletionSize(string[] strs)
    {
        var count = 0;
        for (int col = 0; col < strs[0].Length; col++)
        {
            for (int row = 1; row < strs.Length; row++)
            {
                if (strs[row][col] < strs[row - 1][col])
                {
                    count++;
                    break;
                }
            }
        }
        return count;
    }
}
