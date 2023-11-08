namespace LeetcodeGrind.Solutions;

// 2089. Find Target Indices After Sorting Array
public class P2089
{
    public IList<int> TargetIndices(int[] nums, int target)
    {
        var res = new List<int>();
        Array.Sort(nums);
        var index = Array.BinarySearch(nums, target);
        if (index < 0)
            return res;

        var i = index;
        while (i >= 0 && nums[i] == target)
        {
            res.Add(i);
            i--;
        }

        i = index + 1;
        while (i < nums.Length && nums[i] == target)
        {
            res.Add(i);
            i++;
        }
        res.Sort();
        return res;
    }
}
