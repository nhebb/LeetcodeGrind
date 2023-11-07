namespace LeetcodeGrind.Solutions;

// 657. Robot Return to Origin
public class P0657
{
    public bool JudgeCircle(string moves)
    {
        var x = 0;
        var y = 0;

        for (int i = 0; i < moves.Length; i++)
        {
            var m = moves[i];
            if (m == 'U')
                y++;
            else if (m == 'D')
                y--;
            else if (m == 'L')
                x--;
            else if (m == 'R')
                x++;
        }
        return x == 0 && y == 0;
    }

    public bool JudgeCircleLINQ(string moves)
    {
        return moves.Count(x => x == 'L') == moves.Count(x => x == 'R')
            && moves.Count(x => x == 'U') == moves.Count(x => x == 'D');
    }
}
