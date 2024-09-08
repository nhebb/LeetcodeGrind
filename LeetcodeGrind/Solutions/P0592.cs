namespace LeetcodeGrind.Solutions;

// 592. Fraction Addition and Subtraction
public class P0592
{
    private class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
    }

    public string FractionAddition(string expression)
    {
        var fractions = new List<Fraction>();

        var i = 0;
        while (i < expression.Length)
        {
            var sign = 1;
            if (expression[i] == '-' || expression[i] == '+')
            {
                sign = expression[i] == '-' 
                    ? -1 
                    : 1;
                i++;
            }

            var numerator = 0;
            while (i < expression.Length && char.IsDigit(expression[i]))
            {
                numerator = numerator * 10 + (expression[i] - '0');
                i++;
            }

            // This should be true 100% of the time
            if (expression[i] == '/')
            {
                i++;
            }

            var denominator = 0;
            while (i < expression.Length && char.IsDigit(expression[i]))
            {
                denominator = denominator * 10 + (expression[i] - '0');
                i++;
            }

            fractions.Add(new Fraction
            {
                Numerator = sign * numerator,
                Denominator = denominator
            });
        }

        var lcm = 1;
        foreach (var f in fractions)
        {
            lcm = Lcm(lcm, f.Denominator);
        }

        var sum = 0;
        foreach (var f in fractions)
        {
            sum += f.Numerator * (lcm / f.Denominator);
        }

        var gcd = Gcd(Math.Abs(sum), lcm);
        return $"{sum / gcd}/{lcm / gcd}";
    }

    private int Gcd(int a, int b)
    {
        return b == 0
            ? a
            : Gcd(b, a % b);
    }

    private int Lcm(int a, int b)
    {
        return a / Gcd(a, b) * b;
    }
}
