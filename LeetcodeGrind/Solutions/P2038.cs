namespace LeetcodeGrind.Solutions;

// 2038. Remove Colored Pieces if Both Neighbors are the Same Color
public class P2038
{
    public bool WinnerOfGame(string colors)
    {
        var i = 0;
        var countA = 0;
        var countB = 0;

        while (i < colors.Length)
        {
            var count = 0;
            while (i < colors.Length && colors[i] == 'A')
            {
                count++;
                i++;
            }
            if (count > 2)
                countA += count - 2;

            count = 0;
            while (i < colors.Length && colors[i] == 'B')
            {
                count++;
                i++;
            }
            if (count > 2)
                countB += count - 2;
        }

        return countA > countB;
    }
}
