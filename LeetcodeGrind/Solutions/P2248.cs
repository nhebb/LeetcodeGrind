namespace LeetcodeGrind.Solutions;

// 2248. Intersection of Multiple Arrays
public class P2248
{
    public IList<int> Intersection(int[][] nums)
    {
        Array.Sort(nums[0]);
        if (nums.Length == 1)
        {
            return nums[0];
        }

        var intersect = nums[0].Intersect(nums[1]);

        for (int i = 2; i < nums.Length; i++)
        {
            intersect = intersect.Intersect(nums[i]);
        }

        return intersect.OrderBy(x => x).ToList();
    }
}
