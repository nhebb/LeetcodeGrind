namespace LeetcodeGrind.Solutions;

// 2120. Execution of All Suffix Instructions Staying in a Grid
public class P2120
{
    public int[] ExecuteInstructions(int n, int[] startPos, string s)
    {
        var result = new int[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            var r = startPos[0];
            var c = startPos[1];
            var moves = 0;

            for (int j = i; j < s.Length; j++)
            {
                var dir = s[j];
                if (dir == 'L')
                    c--;
                else if (dir == 'R')
                    c++;
                else if (dir == 'U')
                    r--;
                else
                    r++;

                if (c >= 0 && c < n && r >= 0 && r < n)
                    moves++;
                else
                    break;

            }
            result[i] = moves;
        }

        return result;
    }
}
