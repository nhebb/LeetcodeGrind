using System.Text;

namespace LeetcodeGrind.Solutions;

// 2785. Sort Vowels in a String
public class P2785
{
    public string SortVowels(string s)
    {
        var hsVowels = new HashSet<char>()
        {
            'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u'
        };

        var sbVowels = new StringBuilder();
        var sChars = s.ToCharArray();

        foreach (var c in sChars)
        {
            if (hsVowels.Contains(c))
            {
                sbVowels.Append(c);
            }
        }

        var vowels = sbVowels.ToString().ToCharArray();
        Array.Sort(vowels);

        int j = 0;
        for (int i = 0; i < sChars.Length; i++)
        {
            if (hsVowels.Contains(sChars[i]))
            {
                sChars[i] = vowels[j];
                j++;
            }
        }


        return string.Join("", sChars);
    }
}
