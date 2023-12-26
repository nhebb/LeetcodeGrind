namespace LeetcodeGrind.Solutions;

// 1619. Mean of Array After Removing Some Elements
public class P1619
{
    public double TrimMean(int[] arr)
    {
        var skip = arr.Length / 20;
        var len = arr.Length - 2 * skip;
        Array.Sort(arr);

        double sum = arr.Skip(skip).Take(len).Sum();
        return sum / (double)len;
    }
}
