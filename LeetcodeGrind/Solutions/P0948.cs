namespace LeetcodeGrind.Solutions;

// 948. Bag of Tokens
public class P0948
{
    public int BagOfTokensScore(int[] tokens, int power)
    {
        Array.Sort(tokens);

        var result = 0;
        var score = 0;
        var i = 0;
        var j = tokens.Length - 1;

        while (i <= j)
        {
            if (power >= tokens[i])
            {
                power -= tokens[i++];
                score++;
                result = Math.Max(result, score);
            }
            else if (score > 0)
            {
                score--;
                power += tokens[j--];
            }
            else
            {
                break;
            }
        }

        return result;
    }
}
