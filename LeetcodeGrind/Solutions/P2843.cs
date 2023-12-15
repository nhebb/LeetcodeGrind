namespace LeetcodeGrind.Solutions;

// 2843. Count Symmetric Integers
public class P2843
{
    public int CountSymmetricIntegers(int low, int high)
    {
        var count = 0;

        for (int num = low; num <= high; num++)
        {
            var digits = num.ToString();
            if (digits.Length % 2 == 0)
            {
                var i = 0;
                var j = digits.Length - 1;
                var leftSum = 0;
                var rightSum = 0;

                while (i < j)
                {
                    leftSum += digits[i] - '0';
                    rightSum += digits[j] - '0';
                    i++;
                    j--;
                }

                if (leftSum == rightSum)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
