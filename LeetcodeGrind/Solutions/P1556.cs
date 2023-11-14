namespace LeetcodeGrind.Solutions;

// 1556. Thousand Separator
public class P1556
{
    public string ThousandSeparator(int n)
    {
        return n.ToString("#,##0")
                .Replace(',', '.');
    }
}
