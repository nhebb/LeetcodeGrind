using System.Text;

namespace LeetcodeGrind.Solutions;

// 804. Unique Morse Code Words
public class P0804
{
    public int UniqueMorseRepresentations(string[] words)
    {
        var morse = new string[] { ".-",
            "-...", "-.-.", "-..", ".", "..-.", "--.", "....",
            "..", ".---", "-.-", ".-..", "--", "-.", "---",
            ".--.", "--.-", ".-.", "...", "-", "..-", "...-",
            ".--", "-..-", "-.--", "--.." };

        var hs = new HashSet<string>();
        var sb = new StringBuilder();
        foreach (var word in words)
        {
            foreach (var c in word)
                sb.Append(morse[c - 'a']);
            hs.Add(sb.ToString());
            sb.Clear();
        }

        return hs.Count;
    }
}
