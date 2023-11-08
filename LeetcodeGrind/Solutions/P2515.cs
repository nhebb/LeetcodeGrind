namespace LeetcodeGrind.Solutions;

// 2515. Shortest Distance to Target String in a Circular Array
public class P2515
{
    public int ClosetTarget(string[] words, string target, int startIndex)
    {
        if (!words.Any(x => x == target))
            return -1;

        var n = words.Length;
        var min = n;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == target)
            {
                if (i == startIndex)
                    return 0;

                var curMin = startIndex > i
                    ? Math.Min(startIndex - i, n + i - startIndex)
                    : Math.Min(i - startIndex, n + startIndex - i);

                min = Math.Min(min, curMin);
            }
        }

        return min;
    }
}
