namespace LeetcodeGrind.Solutions;

// 1893. Check if All the Integers in a Range Are Covered
public class P1893
{
    public bool IsCovered(int[][] ranges, int left, int right)
    {
        Array.Sort(ranges, (a, b) => a[0] - b[0]);

        var merged = new List<IList<int>>();
        merged.Add(ranges[0]);

        for (int i = 1; i < ranges.Length; i++)
        {
            if (ranges[i][0] >= merged[^1][0] &&
                ranges[i][1] <= merged[^1][1])
            {
                continue;
            }

            if (ranges[i][0] - 1 <= merged[^1][1])
            {
                merged[^1][1] = ranges[i][1];
            }
            else
            {
                merged.Add(ranges[i]);
            }
        }

        foreach (var range in merged)
        {
            if (range[0] <= left && range[1] >= right)
            {
                return true;
            }
        }

        return false;

    }
}
