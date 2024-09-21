namespace LeetcodeGrind.Solutions;

// 1310. XOR Queries of a Subarray
public class P1310
{
    public int[] XorQueries(int[] arr, int[][] queries)
    {
        var prefix = new int[arr.Length];
        prefix[0] = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            prefix[i] = prefix[i - 1] ^ arr[i];
        }

        var result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            var val = prefix[queries[i][1]];
            if (queries[i][0] > 0)
            {
                val ^= prefix[queries[i][0] - 1];
            }
            result[i] = val;
        }

        return result;
    }
}
