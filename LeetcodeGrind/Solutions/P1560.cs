namespace LeetcodeGrind.Solutions;

// 1560. Most Visited Sector in a Circular Track
public class P1560
{
    public IList<int> MostVisited(int n, int[] rounds)
    {
        // If start <= end, we only count the sections
        // between them (inclusive of end points):
        //
        //     s---------
        // ----******----
        // ---------e
        // 
        // If start > end, we only count the sections 
        // before and after them (inclusive of end points):
        //
        //          s----
        // *****----*****
        // ----e
        // 

        var start = rounds[0];
        var end = rounds[^1];

        var result = new List<int>();
        if (start <= end)
        {
            for (int i = start; i <= end; i++)
            {
                result.Add(i);
            }
        }
        else
        {
            for (int i = start; i <= n; i++)
            {
                result.Add(i);
            }
            for (int i = 1; i <= end; i++)
            {
                result.Add(i);
            }
        }

        result.Sort();
        return result;
    }
}
