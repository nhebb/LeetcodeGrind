using System.Runtime.CompilerServices;

namespace LeetcodeGrind.Solutions;

// 1743. Restore the Array From Adjacent Pairs
public class P1743
{
    public int[] RestoreArray(int[][] adjacentPairs)
    {
        // build dictionary of adjacency pairs - both directions
        var d = new Dictionary<int, List<int>>();
        for (int i = 0; i < adjacentPairs.Length; i++)
        {
            if (d.ContainsKey(adjacentPairs[i][0]))
                d[adjacentPairs[i][0]].Add(adjacentPairs[i][1]);
            else
                d[adjacentPairs[i][0]] = new List<int>() { (adjacentPairs[i][1]) };

            if (d.ContainsKey(adjacentPairs[i][1]))
                d[adjacentPairs[i][1]].Add(adjacentPairs[i][0]);
            else
                d[adjacentPairs[i][1]] = new List<int>() { (adjacentPairs[i][0]) };
        }

        var current = 0;
        var visited = new HashSet<int>();
        var res = new List<int>(adjacentPairs.Length + 1);

        // Find the one of the ends - it will have only
        // 1 adjacent value.
        foreach (var kvp in d)
        {
            if (kvp.Value.Count == 1)
            {
                visited.Add(kvp.Key);
                res.Add(kvp.Key);

                current = kvp.Value[0];
                res.Add(current);
                visited.Add(current);

                break;
            }
        }

        // Crawl through the adjacency dictionary, skipping the
        // visited value and getting next adjacent value.
        var done = false;
        while (!done)
        {
            var values = d[current];
            foreach (var val in values)
            {
                if (values.Count == 1)
                    done = true;

                if (!visited.Contains(val))
                {
                    current = val;
                    visited.Add(val);
                    res.Add(val);
                    break;
                }
            }
        }

        return res.ToArray();
    }
}
