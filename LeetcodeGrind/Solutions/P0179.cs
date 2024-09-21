namespace LeetcodeGrind.Solutions;

// 179. Largest Number
public class P0179
{
    public string LargestNumber(int[] nums)
    {
        // Note: if (!nums.Any(x => x != 0)) didn't improve LC speed

        if (nums.All(x => x == 0))
            return "0";

        Array.Sort(nums, (x, y) => ($"{x}{y}").CompareTo($"{y}{x}"));

        return string.Join("", nums);
    }
}
