namespace LeetcodeGrind.Solutions;

// 3079. Find the Sum of Encrypted Integers
public class P3079
{
    public int SumOfEncryptedInt(int[] nums)
    {
        var sum = 0;

        foreach (var n in nums)
        {
            var sVal = n.ToString();
            var maxDigit = sVal.Max();
            sum += int.Parse(new string(maxDigit, sVal.Length));            
        }

        return sum;
    }
}
