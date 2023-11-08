namespace LeetcodeGrind.Solutions;

// 997. Find the Town Judge
public class P0997
{
    public int FindJudge(int n, int[][] trust)
    {
        // naming: "vote" is a vote of trust
        var voted = new bool[n + 1];
        var voteCount = new int[n + 1];

        foreach (var vote in trust)
        {
            voted[vote[0]] = true;
            voteCount[vote[1]]++;
        }

        for (int i = 1; i <= n; i++)
        {
            // Find the possible judge and check their vote count
            if (!voted[i] && voteCount[i] == n - 1)
                return i;
        }

        return -1;
    }
}
