namespace LeetcodeGrind.Solutions;

public class P3178
{
    public int NumberOfChild(int n, int k)
    {
        if (n == 1)
            return 0;

        var turns = k / (n - 1);
        var whole = turns * (n - 1);
        var rem = whole > 0 
            ? k % whole 
            : k;

        return turns % 2 == 0
            ? 0 + rem
            : n - rem - 1;
    }
}
