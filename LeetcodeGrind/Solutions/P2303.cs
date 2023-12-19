namespace LeetcodeGrind.Solutions;

// 2303. Calculate Amount Paid in Taxes
public class P2303
{
    public double CalculateTax(int[][] brackets, int income)
    {
        double taxes = 0.0;
        var lastBracket = 0;

        for (int i = 0; i < brackets.Length; i++)
        {
            if (income > lastBracket)
            {
                var incomeInBracket = income - lastBracket;
                var taxablePortion = Math.Min(incomeInBracket, brackets[i][0] - lastBracket);
                taxes += taxablePortion * (brackets[i][1] / 100.0);
                lastBracket = brackets[i][0];
            }
            else
            {
                break;
            }
        }

        return taxes;
    }
}
