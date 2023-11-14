namespace LeetcodeGrind.Solutions;

//819. Most Common Word
public class P0819
{
    public string MostCommonWord(string paragraph, string[] banned)
    {
        Array.Sort(banned);
        var splitChars = " !?',;.".ToCharArray();

        var words = paragraph.ToLower()
                             .Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

        var wordCounts = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (Array.BinarySearch<string>(banned, word) < 0)
            {
                if (wordCounts.ContainsKey(word))
                    wordCounts[word]++;
                else
                    wordCounts[word] = 1;
            }
        }

        var maxFreq = 0;
        var maxFreqWord = "";

        foreach (var kvp in wordCounts)
        {
            if (kvp.Value > maxFreq)
            {
                maxFreq = kvp.Value;
                maxFreqWord = kvp.Key;
            }
        }

        return maxFreqWord;
    }
}
