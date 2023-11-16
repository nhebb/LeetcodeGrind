namespace LeetcodeGrind.Solutions;

// 2273. Find Resultant Array After Removing Anagrams
public class P2273
{
    public IList<string> RemoveAnagrams(string[] words)
    {
        var result = new List<string>();

        if (words.Length == 1)
        {
            result.Add(words[0]);
            return result;
        }

        var currentWord = "";
        var lastWord = string.Join("", words[0].ToCharArray().OrderBy(x => x));
        int i = 0;
        int j = 1;

        while (j < words.Length)
        {
            currentWord = string.Join("", words[j].ToCharArray().OrderBy(x => x));

            if (currentWord != lastWord)
            {
                result.Add(words[i]);
                i = j;
                lastWord = currentWord;

                if (j == words.Length - 1)
                {
                    result.Add(words[j]);
                    break;
                }
            }
            else if (j == words.Length - 1)
            {
                result.Add(words[i]);
            }

            j++;
        }

        return result;
    }

    public IList<string> RemoveAnagramsLinq(string[] words)
    {
        var result = words.ToList();
        int i = 1;

        var last = result[0].OrderBy(c => c)
                            .GroupBy(c => c)
                            .ToDictionary(g => g.Key, g => g.Count());

        while (i < result.Count)
        {
            var current = result[i].OrderBy(c => c)
                                   .GroupBy(c => c)
                                   .ToDictionary(g => g.Key, g => g.Count());

            if (last.SequenceEqual(current))
            {
                result.RemoveAt(i);
            }
            else
            {
                last = current;
                i++;
            }
        }

        return result;
    }
}
