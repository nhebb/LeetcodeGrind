namespace LeetcodeGrind.Solutions;

// 2042. Check if Numbers Are Ascending in a Sentence
public class P2042
{
    public bool AreNumbersAscending(string s)
    {
        var tokens = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var numbers = new List<int>();

        foreach (var token in tokens)
        {
            if (char.IsDigit(token[0]) && int.TryParse(token, out int number))
            {
                numbers.Add(number);
            }
        }

        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] <= numbers[i - 1])
            {
                return false;
            }
        }

        return true;
    }
}
