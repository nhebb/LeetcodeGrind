namespace LeetcodeGrind.Solutions;

// 2094. Finding 3-Digit Even Numbers
public class P2094
{
    public int[] FindEvenNumbers(int[] digits)
    {
        var result = new List<int>();

        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] == 0)
            {
                continue;
            }

            for (int j = 0; j < digits.Length; j++)
            {
                if (j == i)
                {
                    continue;
                }

                for (int k = 0; k < digits.Length; k++)
                {
                    if (k == i || k == j || digits[k] % 2 == 1)
                    {
                        continue;
                    }

                    result.Add(digits[i] * 100 + digits[j] * 10 + digits[k]);
                }
            }
        }

        return result.OrderBy(x => x)
                     .Distinct()
                     .ToArray();
    }
}
