namespace LeetcodeGrind.Solutions;

// 1684. Count the Number of Consistent Stringss
public class P1684
{
    public int CountConsistentStrings(string allowed, string[] words)
    {
        var hs = allowed.ToHashSet();

        var count = 0;
        foreach (var word in words)
        {
            var good = true;
            foreach (var c in word)
            {
                if (!hs.Contains(c))
                {
                    good = false;
                    break;
                }
            }
            if (good)
                count++;
        }

        return count;
    }
}
