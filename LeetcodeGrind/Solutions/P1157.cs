namespace LeetcodeGrind.Solutions;

// 1155. Number of Dice Rolls With Target Sum
public class P1157
{
    public int NumRollsToTarget(int n, int k, int target)
    {
        long[][] memo = new long[n + 1][];
        for (int i = 0; i < memo.Length; i++)
        {
            memo[i] = new long[target + 1];
            Array.Fill(memo[i], -1);
        }

        long DPRecurse(int rolls, int dice, int faces, int curTarget)
        {
            const int mod = 1_000_000_007;

            if (curTarget < 0 || rolls > dice)
                return 0;
            if (rolls == dice && curTarget == 0)
                return 1;
            if (memo[rolls][curTarget] != -1)
                return memo[rolls][curTarget];

            long res = 0;
            for (int i = 1; i <= faces; i++)
            {
                res += (DPRecurse(rolls + 1, dice, faces, curTarget - i) % mod);
            }

            memo[rolls][curTarget] = res % mod;

            return memo[rolls][curTarget];
        }

        return (int)DPRecurse(0, n, k, target);
    }
}
