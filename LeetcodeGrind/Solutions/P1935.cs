namespace LeetcodeGrind.Solutions;

// 1935. Maximum Number of Words You Can Type
public class P1935
{
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        var hs = brokenLetters.ToHashSet();
        var words = text.Split(' ');
        var count = 0;

        foreach (var word in words)
        {
            var hasAll = true;

            foreach (var c in word)
            {
                if (hs.Contains(c))
                {
                    hasAll = false;
                    break;
                }
            }

            if (hasAll)
            {
                count++;
            }
        }

        return count;
    }
}
