using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1880. Check if Word Equals Summation of Two Words
public class P1880
{
    public bool IsSumEqual(string firstWord, string secondWord, string targetWord)
    {
        var target = 0;
        foreach (var c in targetWord)
        {
            target *= 10;
            target += c - 'a';
        }

        var first = 0;
        foreach (var c in firstWord)
        {
            first *= 10;
            first += c - 'a';
        }

        var second = 0;
        foreach (var c in secondWord)
        {
            second *= 10;
            second += c - 'a';
        }

        return first + second == target;
    }
}
