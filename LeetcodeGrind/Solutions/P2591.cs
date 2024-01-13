namespace LeetcodeGrind.Solutions;

// 2591. Distribute Money to Maximum Children
public class P2591
{
    public int DistMoney(int money, int children)
    {
        // give $1 to each
        money -= children;
        if (money < 0)
            return -1;

        // $7 remaining to equal $8
        if (money / 7 == children && money % 7 == 0)
            return children;

        if (money / 7 == children - 1 && money % 7 == 3)
            return children - 2;

        return Math.Min(children - 1, money / 7);
    }
}
