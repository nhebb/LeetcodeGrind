namespace LeetcodeGrind.Solutions;

// 2164. Sort Even and Odd Indices Independently
public class P2164
{
    public int[] SortEvenOdd(int[] nums)
    {
        var evens = new List<int>(nums.Length / 2 + 1);
        var odds = new List<int>(nums.Length / 2 + 1);

        for (int i = 0; i < nums.Length; i += 2)
        {
            evens.Add(nums[i]);
        }
        evens.Sort();
        for (int i = 1; i < nums.Length; i += 2)
        {
            odds.Add(nums[i]);
        }
        odds.Sort((a, b) => b - a);

        var j = 0;
        for (int i = 0; i < nums.Length; i += 2)
        {
            nums[i] = evens[j];
            j++;
        }
        j = 0;
        for (int i = 1; i < nums.Length; i += 2)
        {
            nums[i] = odds[j];
            j++;
        }

        return nums;
    }
}
