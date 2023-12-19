namespace LeetcodeGrind.Solutions;

// 2129. Capitalize the Title
public class P2129
{
    public string CapitalizeTitle(string title)
    {
        var words = title.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var capitalized = new List<string>(words.Length);

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length <= 2)
            {
                capitalized.Add(words[i].ToLower());
            }
            else
            {
                capitalized.Add(words[i][0..1].ToUpper() + words[i][1..].ToLower());
            }
        }

        return string.Join(' ', capitalized);
    }
}
