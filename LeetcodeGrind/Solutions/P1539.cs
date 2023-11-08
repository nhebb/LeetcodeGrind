namespace LeetcodeGrind.Solutions;

// 1539. Kth Missing Positive Number
public class P1539
{
    public int FindKthPositive(int[] arr, int k)
    {
        if (k < arr[0])
            return k;
        var last = arr[^1];
        var vals = Enumerable.Range(1, last);
        var missing = vals.Except(arr).ToArray();

        if (missing.Length >= k)
            return missing[k - 1];
        else
            return arr[^1] + k - missing.Length;
    }
}
