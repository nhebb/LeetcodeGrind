namespace LeetcodeGrind.Solutions;

// 1071. Greatest Common Divisor of Strings
public class P1071
{
    public string GcdOfStrings(string str1, string str2)
    {
        if (str1 + str2 != str2 + str1)
            return "";

        int Gcd(int a, int b) => (b == 0) ? a : Gcd(b, a % b);

        var gcdLen = Gcd(str1.Length, str2.Length);
        var subStr1 = str1.Substring(0, gcdLen);
        var subStr2 = str2.Substring(0, gcdLen);

        return subStr1 == subStr2 ? subStr1 : "";
    }
}
