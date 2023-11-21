using System.Text;

namespace LeetcodeGrind.Solutions;

// 1417. Reformat The String
public class P1417
{
    public string Reformat(string s)
    {
        var letters = new List<char>();
        var digits = new List<char>();

        foreach (var c in s)
        {
            if (char.IsDigit(c))
                digits.Add(c);
            else
                letters.Add(c);
        }

        if (Math.Abs(letters.Count - digits.Count) > 1)
            return "";

        var longer = letters.Count > digits.Count ? letters : digits;
        var shorter = letters.Count <= digits.Count ? letters : digits;

        var sb = new StringBuilder();
        for (int i = 0; i < shorter.Count; i++)
        {
            sb.Append(longer[i])
              .Append(shorter[i]);
        }

        if (longer.Count > shorter.Count)
            sb.Append(longer[^1]);

        return sb.ToString();
    }
}
