using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 89. Gray Code
public class P0089
{
    public IList<int> GrayCode(int n)
    {
        var result = new List<int>();
        var limit = Math.Pow(2, n);

        // This problem relies on a math trick.
        // If you've never seen it before, you would
        // have to try a backtracking approach.
        for (int i = 0; i < limit; i++)
        {
            result.Add(i ^ i >> 1);
        }

        return result;
    }
}

