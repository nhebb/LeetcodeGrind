namespace LeetcodeGrind.Solutions;

// 1041. Robot Bounded In Circle
public class P1041
{
    public bool IsRobotBounded(string instructions)
    {
        var d = 'N';
        var x = 0;
        var y = 0;

        var DR = new Dictionary<char, char>();
        DR['N'] = 'E';
        DR['E'] = 'S';
        DR['S'] = 'W';
        DR['W'] = 'N';

        var DL = new Dictionary<char, char>();
        DL['N'] = 'W';
        DL['E'] = 'N';
        DL['S'] = 'E';
        DL['W'] = 'S';

        var radii = new List<int>();

        for (int i = 0; i < 4; i++)
        {
            foreach (char c in instructions)
            {
                if (c == 'G')
                {
                    if (d == 'N')
                        y++;
                    else if (d == 'S')
                        y--;
                    else if (d == 'E')
                        x++;
                    else
                        x--;
                }
                else if (c == 'L')
                    d = DL[d];
                else //if (c == 'R')
                    d = DR[d];
            }
            if (x == 0 && y == 0)
                return true;

            radii.Add(x * x + y * y);
        }

        if (radii[^1] > radii[0])
            return false;

        return true;
    }
}
