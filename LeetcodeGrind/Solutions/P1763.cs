namespace LeetcodeGrind.Solutions;

// 1763. Longest Nice Substring
public class P1763
{
    public string LongestNiceSubstring(string s)
    {
        var longest = "";

        void CheckSubstring(string str)
        {
            if (str.Length <= longest.Length || str.Length < 2)
                return;

            // 32 == difference between lower and upper ASCII values
            if (str.Length == 2 && Math.Abs(str[0] - str[1]) == 32)
            {
                longest = str;
                return;
            }

            var lower = new bool[26];
            var upper = new bool[26];
            foreach (var c in str)
            {
                if (char.IsUpper(c))
                    upper[c - 'A'] = true;
                else
                    lower[c - 'a'] = true;
            }


            var delimiters = new List<char>();
            for (int i = 0; i < 26; i++)
            {
                // XOR lower and upper ASCII values to find
                // non-matched characters
                if (lower[i] ^ upper[i])
                {
                    delimiters.Add(lower[i]
                        ? (char)('a' + i)
                        : (char)('A' + i));
                }
            }

            if (!delimiters.Any())
            {
                longest = str;
            }
            else
            {
                var parts = str.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var part in parts)
                {
                    if (part.Length > longest.Length)
                        CheckSubstring(part);
                }
            }
        }

        CheckSubstring(s);

        return longest;
    }
}
