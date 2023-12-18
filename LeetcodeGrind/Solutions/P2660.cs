namespace LeetcodeGrind.Solutions;

// 2660. Determine the Winner of a Bowling Game
public class P2660
{
    public int IsWinner(int[] player1, int[] player2)
    {
        var score1 = player1[0];
        var score2 = player2[0];

        if (player1.Length > 1)
        {
            if (player1[0] == 10)
                score1 += 2 * player1[1];
            else
                score1 += player1[1];

            if (player2[0] == 10)
                score2 += 2 * player2[1];
            else
                score2 += player2[1];

            for (int i = 2; i < player1.Length; i++)
            {
                if (player1[i - 2] == 10 || player1[i - 1] == 10)
                    score1 += 2 * player1[i];
                else
                    score1 += player1[i];

                if (player2[i - 2] == 10 || player2[i - 1] == 10)
                    score2 += 2 * player2[i];
                else
                    score2 += player2[i];
            }
        }

        if (score1 > score2)
            return 1;
        else if (score1 < score2)
            return 2;
        else
            return 0;
    }
}

