namespace LeetcodeGrind.Solutions;

// 2657. Find the Prefix Common Array of Two Arrays
public class P2657
{
    public int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
        var hsA = new HashSet<int>();
        var hsB = new HashSet<int>();
        var hsCommon = new HashSet<int>();

        var C = new int[A.Length];

        for (int i = 0; i < A.Length; i++)
        {
            hsA.Add(A[i]);
            hsB.Add(B[i]);

            if (hsB.Contains(A[i]))
                hsCommon.Add(A[i]);
            if (hsA.Contains(B[i]))
                hsCommon.Add(B[i]);

            C[i] = hsCommon.Count;
        }

        return C;
    }
}
