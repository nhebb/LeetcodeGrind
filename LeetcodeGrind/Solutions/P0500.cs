namespace LeetcodeGrind.Solutions;

// 500. Keyboard Row
public class P0500
{
    public string[] FindWords(string[] words)
    {
        var row1 = "qwertyuiop".ToCharArray();
        var row2 = "asdfghjkl".ToCharArray();
        var row3 = "zxcvbnm".ToCharArray();

        return words.Where(w => w.ToLower().Except(row1).Count() == 0 ||
                                w.ToLower().Except(row2).Count() == 0 ||
                                w.ToLower().Except(row3).Count() == 0)
                    .ToArray();
    }
}
