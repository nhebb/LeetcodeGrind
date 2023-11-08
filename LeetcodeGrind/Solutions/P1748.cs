namespace LeetcodeGrind.Solutions;

// 1748 Sum of Unique Elements
public class P1748
{
    public int SumOfUnique(int[] nums)
    {
        const int maxLength = 101;
        var freq = new int[maxLength];
        foreach (var num in nums)
            freq[num]++;

        var sum = 0;
        for (int i = 1; i < freq.Length; i++)
            if (freq[i] == 1)
                sum += i;

        return sum;
    }
}
