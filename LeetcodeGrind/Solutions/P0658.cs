namespace LeetcodeGrind.Solutions;

// 658. Find K Closest Elements
public class P0658
{
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        return arr.OrderBy(a => Math.Abs(x - a))
                  .ThenBy(a => a)
                  .Take(k)
                  .OrderBy(a => a)
                  .ToList();
    }
}
