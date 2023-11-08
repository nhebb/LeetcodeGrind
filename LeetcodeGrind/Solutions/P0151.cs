namespace LeetcodeGrind.Solutions;

// 151. Reverse Words in a String
public class P0151
{
    public string ReverseWords(string s)
    {
        var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return string.Join(" ", words.Reverse());
    }
}
