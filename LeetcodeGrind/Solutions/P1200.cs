namespace LeetcodeGrind.Solutions;

// 1200. Minimum Absolute Difference
public class P1200
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        Array.Sort(arr);

        var min = int.MaxValue;
        for (int i = 1; i < arr.Length; i++)
        {
            var delta = arr[i] - arr[i - 1];
            min = Math.Min(min, delta);
        }

        var result = new List<IList<int>>();
        for (int i = 1; i < arr.Length; i++)
        {
            var delta = arr[i] - arr[i - 1];
            if (delta == min)
            {
                result.Add(new int[] { arr[i - 1], arr[i] });
            }
        }

        return result;
    }
}
