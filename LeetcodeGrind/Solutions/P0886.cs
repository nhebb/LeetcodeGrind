namespace LeetcodeGrind.Solutions;

// 886. Possible Bipartition

public class P0886
{
    public bool PossibleBipartition(int n, int[][] dislikes)
    {
        var dict = new Dictionary<int, List<int>>();

        // set up parent array for union find
        var parent = new int[n + 1];
        for (int i = 0; i < parent.Length; i++)
            parent[i] = i;

        // local functions for union find
        void Union(int x, int y)
        {
            parent[Find(x)] = parent[Find(y)];
        }

        int Find(int x)
        {
            if (parent[x] != x)
                parent[x] = Find(parent[x]);

            return parent[x];
        }

        // Add key-value entries for both indices of ith dislikes
        foreach (var dislike in dislikes)
        {
            if (dict.TryGetValue(dislike[0], out var list1))
                list1.Add(dislike[1]);
            else
                dict[dislike[0]] = new List<int> { dislike[1] };

            if (dict.TryGetValue(dislike[1], out var list2))
                list2.Add(dislike[0]);
            else
                dict[dislike[1]] = new List<int> { dislike[0] };
        }

        // iterate over the possible people values (1 to n) ...
        for (int person = 1; person <= n; person++)
        {
            if (!dict.ContainsKey(person))
                continue;

            // ... and then check if dislikes are in the same union set
            foreach (var enemy in dict[person])
            {
                if (Find(person) == Find(enemy))
                    return false;

                Union(dict[person][0], enemy);
            }
        }

        return true;
    }
}
