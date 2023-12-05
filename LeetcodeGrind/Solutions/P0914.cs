namespace LeetcodeGrind.Solutions;

// 914. X of a Kind in a Deck of Cards
public class P0914
{
    public bool HasGroupsSizeX(int[] deck)
    {
        var d = deck.GroupBy(x => x)
                    .ToDictionary(g => g.Key, g => g.Count());

        var counts = d.Values.ToArray();
        var min = counts.Min();

        if (min == 1)
        {
            return false;
        }

        var factors = new List<int>();
        for (int i = 2; i <= min; i++)
        {
            if (min % i == 0)
            {
                factors.Add(i);
            }
        }

        foreach (var factor in factors)
        {
            if (counts.All(x => x % factor == 0))
            {
                return true;
            }
        }

        return false;
    }
}
