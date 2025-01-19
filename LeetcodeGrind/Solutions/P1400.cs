namespace LeetcodeGrind.Solutions;

// TODO: 1400. Construct K Palindrome Strings
// Wrong answer
public class P1400
{
    public bool CanConstruct(string s, int k)
    {
        var counts = s.GroupBy(c => c)
                      .ToDictionary(g => g.Key, g => g.Count());

        var odd = 0;
        var even = 0;

        foreach (var kvp in counts)
        {
            if (kvp.Value % 2 == 0)
                even++;
            else
                odd++;
        }

        if (odd > 1)
            return false;

        var maxCombos = Math.Max(1, even * (even - 1) / 2);

        return maxCombos >= k;
    }
}
