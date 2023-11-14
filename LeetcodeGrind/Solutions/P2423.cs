namespace LeetcodeGrind.Solutions;

// 2423. Remove Letter To Equalize Frequency
public class P2423
{
    public bool EqualFrequency(string word)
    {
        // count the frequency of each letter
        var arr = new int[26];
        foreach (char c in word)
            arr[c - 'a']++;

        // group the letters by frequency
        var freq = new Dictionary<int, List<char>>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == 0)
                continue;

            char letter = (char)(i + 'a');
            if (freq.TryGetValue(arr[i], out var list))
                list.Add(letter);
            else
                freq[arr[i]] = new List<char>() { letter };
        }

        // If there are more than 2 frequency groups,
        // you can't remove just one index to achieve
        // frequency
        if (freq.Count > 2)
            return false;

        var min = freq.Keys.Min();
        var max = freq.Keys.Max();

        // all letters are the same
        if (freq.Count == 1 && freq[min].Count == 1)
            return true;

        // A single letter that appears only once
        if (min == 1 && freq[min].Count == 1)
            return true;

        // all letters appear only once
        if (min == 1 && max == 1)
            return true;

        // one letter appears one more time than the rest
        if (max - min == 1 && freq[max].Count == 1)
            return true;

        return false;
    }
}
