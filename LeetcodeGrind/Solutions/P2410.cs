namespace LeetcodeGrind.Solutions;

// 2410. Maximum Matching of Players With Trainers
public class P2410
{
    public int MatchPlayersAndTrainers(int[] players, int[] trainers)
    {
        Array.Sort(players);
        Array.Sort(trainers);

        var count = 0;
        var i = players.Length - 1;
        var j = trainers.Length - 1;

        while (i >= 0 && j >= 0)
        {
            if (players[i] > trainers[j])
            {
                i--;
            }
            else
            {
                count++;
                i--;
                j--;
            }
        }

        return count;
    }
}
