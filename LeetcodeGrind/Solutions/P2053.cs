namespace LeetcodeGrind.Solutions;

// 2053. Kth Distinct String in an Array
public class P2053
{
    public string KthDistinct(string[] arr, int k)
    {
        var d = arr.GroupBy(x => x)
                   .ToDictionary(g => g.Key, g => g.Count());

        for (int i = 0; i < arr.Length; i++)
        {
            if (d[arr[i]] == 1)
            {
                k--;
                if (k == 0)
                {
                    return arr[i];
                }
            }
        }

        return "";
    }
}
