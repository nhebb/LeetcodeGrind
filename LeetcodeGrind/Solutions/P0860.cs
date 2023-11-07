namespace LeetcodeGrind.Solutions;

// 860. Lemonade Change
public class P0860
{
    public bool LemonadeChange(int[] bills)
    {
        var change = 0;
        for (int i = 0; i < bills.Length; i++)
        {
            change += 5;
            change -= bills[i] - 5;

            if (change < 0)
                return false;
        }

        return true;
    }
}
