namespace LeetcodeGrind.Solutions;

// 1608. Special Array With X Elements Greater Than or Equal X
public class P1608
{
    public int SpecialArray(int[] nums)
    {
        var counts = new int[1001];
        for (int i = 0; i < nums.Length; i++)
        {
            counts[nums[i]]++;
        }

        var suffix = new int[1001];
        suffix[^1] = counts[^1];

        for (int i = counts.Length - 2; i >= 0; i--)
        {
            suffix[i] = counts[i] + suffix[i + 1];
            if (suffix[i] == i)
            {
                return i;
            }
        }

        return -1;
    }
}
