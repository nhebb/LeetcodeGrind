namespace LeetcodeGrind.Solutions;

// 2465. Number of Distinct Averages
public class P2465
{
    public int DistinctAverages(int[] nums)
    {
        var hs = new HashSet<int>();
        Array.Sort(nums);

        var i = 0;
        var j = nums.Length - 1;

        while (i < j)
        {
            // calculating actual average isn't needed
            hs.Add(nums[i] + nums[j]);
            i++;
            j--;
        }

        return hs.Count();
    }
}
