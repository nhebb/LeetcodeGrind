namespace LeetcodeGrind.Solutions;

// 2306. Naming a Company
public class P2306
{
    public long DistinctNames(string[] ideas)
    {
        var suffixes = new HashSet<string>[26];
        for (int i = 0; i < 26; i++)
            suffixes[i] = new HashSet<string>();

        // make hashset of names by first letter
        foreach (var idea in ideas)
            suffixes[idea[0] - 'a'].Add(idea.Substring(1));

        long result = 0;

        // compare each hashset to the other hashsets
        for (int i = 0; i < 25; i++)
        {
            var iCount = suffixes[i].Count;
            for (int j = i + 1; j < 26; j++)
            {
                // get the count of common suffixes
                long common = suffixes[i].Intersect(suffixes[j]).Count();
                var jCount = suffixes[j].Count;

                // unique suffixes in 1st set x unique suffixes in 2nd 
                // set x 2 for order swap (e.g., Tin, Man => MinTan, TanMin)
                result += 2 * (iCount - common) * (jCount - common); ;
            }
        }
        return result;
    }
}
