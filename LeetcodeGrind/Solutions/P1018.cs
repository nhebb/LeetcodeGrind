namespace LeetcodeGrind.Solutions;

// 1018. Binary Prefix Divisible By 5
public class P1018
{
    public IList<bool> PrefixesDivBy5(int[] nums)
    {
        var answer = new bool[nums.Length];
        var val = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            val *= 2; // weird but *= 2 usually performs better on LC than <<= 1
            val |= nums[i];
            answer[i] = val % 5 == 0;
            val %= 5;   // otherwise it will overflow
        }

        return answer;
    }
}
