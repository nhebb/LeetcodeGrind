namespace LeetcodeGrind.Solutions;

// 2496. Maximum Value of a String in an Array
public class P2496
{
    public int MaximumValue(string[] strs)
    {
        var maxScore = int.MinValue;

        foreach (var s in strs)
        {
            var score = int.TryParse(s, out var val)
                ? val
                : s.Length;

            maxScore = Math.Max(maxScore, score);
        }

        return maxScore;
    }
}
