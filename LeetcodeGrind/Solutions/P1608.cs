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

        var postfix = new int[1001];
        postfix[^1] = counts[^1];

        for (int i = counts.Length - 2; i >= 0; i--)
        {
            postfix[i] = counts[i] + postfix[i + 1];
            if (postfix[i] == i)
            {
                return i;
            }
        }

        return -1;
    }
}
