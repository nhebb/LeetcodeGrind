namespace LeetcodeGrind.Solutions;

// 2744. Find Maximum Number of String Pairs
public class P2744
{
    public int MaximumNumberOfStringPairs(string[] words)
    {
        var taken = new bool[words.Length];
        var count = 0;

        for (int i = 0; i < words.Length - 1; i++)
        {
            if (taken[i])
                continue;

            for (int j = i + 1; j < words.Length; j++)
            {
                if (taken[j])
                    continue;

                var reversed = string.Join("", words[j].Reverse());
                if (words[i] == reversed)
                {
                    taken[i] = true;
                    taken[j] = true;
                    count++;
                }
            }
        }

        return count;
    }
}
