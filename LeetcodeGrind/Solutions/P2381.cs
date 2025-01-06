namespace LeetcodeGrind.Solutions;

// 2381. Shifting Letters II
public class P2381
{
    public string ShiftingLetters(string s, int[][] shifts)
    {
        var deltas = new int[s.Length];

        foreach (var shift in shifts)
        {
            var direction = shift[2] == 1 ? 1 : -1;
            for (int i = shift[0]; i <= shift[1]; i++)
            {
                deltas[i] += direction;
            }
        }

        var chars = s.ToCharArray();
        for (int i = 0; i < deltas.Length; i++)
        {
            var delta = deltas[i] % 26;
            if (delta == 0)
                continue;

            var shift = chars[i] + delta;
            if (shift < 'a')
            {
                var diff = 'a' - shift;
                shift = 'z' + 1 - diff;
            }
            else if (shift > 'z')
            {
                var diff = shift - 'z';
                shift = 'a' - 1 + diff;
            }
            chars[i] = (char)shift;
        }

        return new string(chars);
    }
}
