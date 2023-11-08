namespace LeetcodeGrind.Solutions;

// 17. Letter Combinations of a Phone Number
public class P0017
{
    public IList<string> LetterCombinations(string digits)
    {
        List<string> combos = new List<string>();

        if (string.IsNullOrWhiteSpace(digits))
            return combos;

        var lookup = new Dictionary<char, List<string>>
        {
            { '2', new List<string>() { "a", "b", "c" } },
            { '3', new List<string>() { "d", "e", "f" } },
            { '4', new List<string>() { "g", "h", "i" } },
            { '5', new List<string>() { "j", "k", "l" } },
            { '6', new List<string>() { "m", "n", "o" } },
            { '7', new List<string>() { "p", "q", "r", "s" } },
            { '8', new List<string>() { "t", "u", "v" } },
            { '9', new List<string>() { "w", "x", "y", "z" } }
        };

        void ProcessDigits(string substr, int i)
        {
            if (i == digits.Length)
            {
                combos.Add(substr);
            }
            else
            {
                var letters = lookup[digits[i]];
                foreach (var letter in letters)
                {
                    ProcessDigits(substr + letter, i + 1);
                }
            }
        }

        foreach (var letter in lookup[digits[0]])
        {
            ProcessDigits(letter, 1);
        }

        return combos.OrderBy(x => x).Distinct().ToList();
    }
}
