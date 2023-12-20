namespace LeetcodeGrind.Solutions;

// 1805. Number of Different Integers in a String
public class P1805
{
    public int NumDifferentIntegers(string word)
    {
        var chars = new char[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            chars[i] = char.IsDigit(word[i])
                ? word[i]
                : ' ';
        }

        var nums = string.Join("", chars)
                         .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var hs = new HashSet<string>();
        for (int i = 0; i < nums.Length; i++)
        {
            var val = nums[i].TrimStart('0');
            if (string.IsNullOrEmpty(val))
            {
                hs.Add("0");
            }
            else
            {
                hs.Add(val);
            }
        }

        return hs.Count;
    }
}
