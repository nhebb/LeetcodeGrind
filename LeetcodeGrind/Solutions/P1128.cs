namespace LeetcodeGrind.Solutions;

// 1128. Number of Equivalent Domino Pairs
public class P1128
{
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        var d = new Dictionary<(int, int), int>();
        foreach (var domino in dominoes)
        {
            var lower = domino[0];
            var higher = domino[1];
            if (lower > higher)
            {
                (lower, higher) = (higher, lower);
            }

            if (d.ContainsKey((lower, higher)))
            {
                d[(lower, higher)]++;
            }
            else
            {
                d[(lower, higher)] = 1;
            }
        }

        var count = 0;
        foreach (var kvp in d)
        {
            if (kvp.Value > 1)
            {
                count += kvp.Value * (kvp.Value - 1) / 2;
            }
        }

        return count;
    }
}
