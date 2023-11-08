namespace LeetcodeGrind.Solutions;

// 2007. Find Original Array From Doubled Array
public class P2007
{
    public int[] FindOriginalArray(int[] changed)
    {
        if (changed.Length % 2 == 1)
            return Array.Empty<int>();

        var targetLength = changed.Length / 2;

        Array.Sort(changed);
        var d = new Dictionary<int, int>();
        foreach (var num in changed)
        {
            if (d.TryGetValue(num, out int val))
                d[num] = val + 1;
            else
                d[num] = 1;
        }

        // special edge case of zeroes:
        if (d.TryGetValue(0, out var zeroCount))
        {
            if (zeroCount == 1 || zeroCount % 2 == 1)
                return Array.Empty<int>();
        }

        var count = 0;
        var res = new List<int>();
        for (int i = changed.Length - 1; i >= 0; i--)
        {
            if (changed[i] % 2 == 1 || changed[i] == 1)
                continue;

            var half = changed[i] / 2;

            if (d.TryGetValue(half, out var halfValCount) &&
                d.TryGetValue(changed[i], out int changedValCount))
            {
                d[changed[i]]--;
                if (d[changed[i]] == 0)
                    d.Remove(changed[i]);

                if (!d.ContainsKey(half))
                    break;

                d[half]--;
                if (d[half] == 0)
                    d.Remove(half);

                res.Add(half);
                count++;
                if (count == targetLength)
                    break;
            }
        }

        if (count == targetLength)
            return res.ToArray();

        return Array.Empty<int>();
    }
}
