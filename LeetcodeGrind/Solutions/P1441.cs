namespace LeetcodeGrind.Solutions;

// 1441. Build an Array With Stack Operations
public class P1441
{
    public IList<string> BuildArray(int[] target, int n)
    {
        var result = new List<string>();
        int i = 1;
        int j = 0;

        while (i <= n)
        {
            result.Add("Push");
            if (i == target[j])
            {
                j++;
            }
            else
            {
                result.Add("Pop");
            }
            i++;
        }

        return result;
    }

    // Surprisingly, the following is faster using target.Contains(i)
    // instead of using a hash set.
    public IList<string> BuildArray2(int[] target, int n)
    {
        var result = new List<string>();
        var hs = target.ToHashSet();

        for (int i = 1; i <= target[^1]; i++)
        {
            if (hs.Contains(i))
            {
                result.Add("Push");
            }
            else
            {
                result.Add("Push");
                result.Add("Pop");
            }
        }
        return result;
    }
}
