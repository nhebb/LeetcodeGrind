namespace LeetcodeGrind.Solutions;

// 2259. Remove Digit From Number to Maximize Result
public class P2259
{
    public string RemoveDigit(string number, char digit)
    {
        for (int i = 0; i < number.Length - 1; i++)
        {
            if (number[i] == digit && digit < number[i + 1])
            {
                return number.Remove(i, 1);
            }
        }

        var index = number.LastIndexOf(digit);
        return number.Remove(index, 1);
    }
}
