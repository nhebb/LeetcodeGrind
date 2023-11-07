namespace LeetcodeGrind.Solutions;

// 43. Multiply Strings
public class P0043
{
    public string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0")
        {
            return "0";
        }
        var answer = new int[num1.Length + num2.Length];
        Array.Fill(answer, 0);

        var onesPlace = answer.Length - 1;

        for (int i = num1.Length - 1; i >= 0; i--)
        {
            var k = onesPlace;
            var factor1 = num1[i] - '0';

            for (int j = num2.Length - 1; j >= 0; j--)
            {
                answer[k] += (num1[i] - '0') * (num2[j] - '0');
                if (answer[k] >= 10)
                {
                    answer[k - 1] += (answer[k] / 10);
                    answer[k] %= 10;
                }
                k--;
            }
            onesPlace--;
        }

        for (int i = answer.Length - 1; i >= 0; i--)
        {
            int carry = 0;
            if (answer[i] >= 10)
            {
                carry = answer[i] / 10;
                answer[i] %= 10;
                answer[i - 1] += carry;
            }
        }

        var result = String.Join("", answer);

        // skip leading 0's
        int x = 0;
        while (result[x] == '0')
            x++;

        return result[x..];
    }
}
