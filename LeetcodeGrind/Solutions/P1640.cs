namespace LeetcodeGrind.Solutions;

// 1640. Check Array Formation Through Concatenation
public class P1640
{
    public bool CanFormArray(int[] arr, int[][] pieces)
    {
        var d = new Dictionary<int, int[]>();
        for (int i = 0; i < pieces.Length; i++)
        {
            d[pieces[i][0]] = pieces[i];
        }

        var result = new List<int>();
        var j = 0;
        while (j < arr.Length)
        {
            if (!d.ContainsKey(arr[j]))
            {
                return false;
            }

            result.AddRange(d[arr[j]]);
            j += d[arr[j]].Length;
        }

        return arr.SequenceEqual(result);
    }
}
