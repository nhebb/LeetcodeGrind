namespace LeetcodeGrind.Solutions;

// 1592. Rearrange Spaces Between Words
public class P1592
{
    public string ReorderSpaces(string text)
    {
        var spaces = text.Count(c => c == ' ');
        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string result;
        if (words.Length == 1)
        {
            result = words[0] + new string(' ', spaces);
        }
        else
        {
            var separator = new string(' ', spaces / (words.Length - 1));
            var suffix = spaces % (words.Length - 1) > 0
                ? new string(' ', spaces % (words.Length - 1))
                : "";

            result = string.Join(separator, words) + suffix;
        }
        return result;
    }
}
