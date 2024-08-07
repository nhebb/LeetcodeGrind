namespace LeetcodeGrind.Solutions;

// 1460. Make Two Arrays Equal by Reversing Subarrays
public class P1460
{
    public bool CanBeEqual(int[] target, int[] arr)
    {
        var targetDict = target.GroupBy(x => x)
                               .ToDictionary(g => g.Key, g => g.Count());

        var arrDict = arr.GroupBy(x => x)
                         .ToDictionary(g => g.Key, g => g.Count());

        foreach (var kvp in arrDict)
        {
            if (!targetDict.ContainsKey(kvp.Key) ||
                kvp.Value != targetDict[kvp.Key])
            {
                return false;
            }
        }

        return true;
    }

    public bool CanBeEqual2(int[] target, int[] arr)
    {
        if (target.Length != arr.Length)
            return false;

        Array.Sort(target);
        Array.Sort(arr);

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != target[i])
            {
                return false;
            }
        }

        return true;
    }
}
