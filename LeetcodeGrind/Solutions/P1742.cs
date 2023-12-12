namespace LeetcodeGrind.Solutions;

// 1742. Maximum Number of Balls in a Box
public class P1742
{
    public int CountBalls(int lowLimit, int highLimit)
    {
        var boxCounts = new Dictionary<int, int>();

        for (int i = lowLimit; i <= highLimit; i++)
        {
            var ball = i.ToString();
            var boxNumber = 0;
            foreach (var c in ball)
            {
                boxNumber += c - '0';
            }

            if (boxCounts.ContainsKey(boxNumber))
                boxCounts[boxNumber]++;
            else
                boxCounts[boxNumber] = 1;
        }

        return boxCounts.Values.Max();
    }
}
