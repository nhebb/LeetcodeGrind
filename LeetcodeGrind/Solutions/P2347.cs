namespace LeetcodeGrind.Solutions;

// 2347. Best Poker Hand
public class P2347
{
    public string BestHand(int[] ranks, char[] suits)
    {
        var rd = ranks.GroupBy(x => x)
                      .ToDictionary(g => g.Key, g => g.Count());
        var sd = suits.GroupBy(x => x)
                      .ToDictionary(g => g.Key, g => g.Count());

        if (sd.Values.Max() == 5)
        {
            return "Flush";
        }
        
        if (rd.Values.Max() >= 3)
        {
            return "Three of a Kind";
        
        }
        if (rd.Values.Max() == 2)
        {
            return "Pair";
        }

        return "High Card";
    }
}
