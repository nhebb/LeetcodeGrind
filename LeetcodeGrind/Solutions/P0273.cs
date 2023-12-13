namespace LeetcodeGrind.Solutions;

// 273. Integer to English Words
public class P0273
{
    public string NumberToWords(int num)
    {
        if (num == 0)
        {
            return "Zero";
        }

        var d = new Dictionary<int, string>();
        d[0] = "";
        d[1] = "One";
        d[2] = "Two";
        d[3] = "Three";
        d[4] = "Four";
        d[5] = "Five";
        d[6] = "Six";
        d[7] = "Seven";
        d[8] = "Eight";
        d[9] = "Nine";
        d[10] = "Ten";
        d[11] = "Eleven";
        d[12] = "Twelve";
        d[13] = "Thirteen";
        d[14] = "Fourteen";
        d[15] = "Fifteen";
        d[16] = "Sixteen";
        d[17] = "Seventeen";
        d[18] = "Eighteen";
        d[19] = "Nineteen";
        d[20] = "Twenty";
        d[30] = "Thirty";
        d[40] = "Forty";
        d[50] = "Fifty";
        d[60] = "Sixty";
        d[70] = "Seventy";
        d[80] = "Eighty";
        d[90] = "Ninety";

        string GetHundreds(int n)
        {
            if (n / 100 > 0)
            {
                return $"{d[n / 100]} Hundred {GetTens(n % 100)}".Trim();
            }
            return $"{GetTens(n % 100)}".Trim();
        }

        string GetTens(int n)
        {
            var ones = n % 10;
            var tens = n - ones;
            if (n >= 20)
                return $"{d[tens]} {d[ones]}";
            else if (n > 0)
                return $"{d[n]}";
            return "";
        }

        var res = "";

        var billions = num / 1_000_000_000;
        if (billions > 0)
        {
            res = $"{d[billions]} Billion ";
            num -= billions * 1_000_000_000;
        }

        var millions = num / 1_000_000;
        if (millions > 0)
        {
            res += $"{GetHundreds(millions)} Million ";
            num -= millions * 1_000_000;
        }

        var thousands = num / 1_000;
        if (thousands > 0)
        {
            res += $"{GetHundreds(thousands)} Thousand ";
            num -= thousands * 1_000;
        }

        res += GetHundreds(num);
        res = res.Replace("  ", " ").Trim();

        return res;
    }

}
