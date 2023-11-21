namespace LeetcodeGrind.Solutions;

// 860. Lemonade Change
public class P0860
{
    public bool LemonadeChange(int[] bills)
    {
        var twenties = 0;
        var tens = 0;
        var fives = 0;

        for (int i = 0; i < bills.Length; i++)
        {
            if (bills[i] == 20)
            {
                twenties++;
                if (tens > 0 && fives > 0)
                {
                    tens--;
                    fives--;
                }
                else if (fives >= 3)
                {
                    fives -= 3;
                }
                else
                {
                    return false;
                }
            }
            else if (bills[i] == 10)
            {
                tens++;
                if (fives >0)
                {
                    fives--;
                }
                else
                {
                    return false;
                }
            }
            else // (bills[i] == 5)
            {
                fives++;
            }
        }

        return true;
    }
}
