namespace LeetcodeGrind.Solutions;

// 953. Verifying an Alien Dictionary
public class P0953
{
    public bool IsAlienSorted(string[] words, string order)
    {
        var d = new Dictionary<char, int>();
        for (int i = 0; i < order.Length; i++)
            d[order[i]] = i;

        for (int i = 0; i < words.Length - 1; i++)
        {
            var len1 = words[i].Length;
            var len2 = words[i + 1].Length;
            var minLen = Math.Min(len1, len2);
            var equal = true;
            for (int j = 0; j < minLen; j++)
            {
                var idx1 = d[words[i][j]];
                var idx2 = d[words[i + 1][j]];

                // not sorted
                if (idx1 > idx2)
                    return false;
                // sorted, move to next word pair
                if (idx1 < idx2)
                {
                    equal = false;
                    break;
                }
            }
            // all letters up to minLen match, but
            // first word is longer than second word
            if (equal && len1 > len2)
                return false;
        }
        return true;
    }
}
