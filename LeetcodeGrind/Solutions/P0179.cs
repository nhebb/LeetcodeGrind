namespace LeetcodeGrind.Solutions;

// 179. Largest Number
public class P0179
{
    public string LargestNumber(int[] nums)
    {
        if (nums.All(x => x == 0))
            return "0";

        Array.Sort(nums, (x, y) => ($"{x}{y}").CompareTo($"{y}{x}"));

        return string.Join("", nums);
    }
}
