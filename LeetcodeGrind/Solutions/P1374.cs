namespace LeetcodeGrind.Solutions;

// 1374. Generate a String With Characters That Have Odd Counts
public class P1374
{
    public string GenerateTheString(int n)
    {
        return n % 2 == 0
            ? new string('a', n - 1) + "z"
            : new string('a', n);
    }
}
