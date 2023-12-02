namespace LeetcodeGrind.Solutions;

// 824. Goat Latin

public class P0824
{
    public string ToGoatLatin(string sentence)
    {
        var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var vowels = "aeiouAEIOU".ToHashSet();

        for (int i = 0; i < words.Length; i++)
        {
            var suffix = "ma" + new string('a', i + 1);
            if (vowels.Contains(words[i][0]))
            {
                words[i] = words[i] + suffix;
            }
            else
            {
                words[i] = words[i].Substring(1) + words[i][0] + suffix;
            }
        }

        return string.Join(" ", words);
    }
}
