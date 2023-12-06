namespace LeetcodeGrind.Solutions;

// 1078. Occurrences After Bigram
public class P1078
{
    public string[] FindOcurrences(string text, string first, string second)
    {
        var result = new List<string>();

        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (words.Length < 3)
        {
            return result.ToArray();
        }

        var one = words[0];
        var two = words[1];

        var i = 2;
        while (i < words.Length)
        {
            if (one == first && two == second)
            {
                result.Add(words[i]);
            }
            one = two;
            two = words[i];
            i++;
        }

        return result.ToArray();
    }
}
