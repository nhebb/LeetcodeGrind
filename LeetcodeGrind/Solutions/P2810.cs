namespace LeetcodeGrind.Solutions;

// 2810. Faulty Keyboard
public class P2810
{
    public string FinalString(string s)
    {
        var chars = new List<char>();
        foreach (var c in s)
        {
            if (c == 'i')
                chars.Reverse();
            else
                chars.Add(c);
        }
        return new string(chars.ToArray());
    }
}
