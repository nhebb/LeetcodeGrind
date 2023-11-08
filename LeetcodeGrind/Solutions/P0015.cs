namespace LeetcodeGrind.Solutions;

// 15. 3Sum
public class P0015
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> triplets = new List<IList<int>>();

        if (nums == null || nums.Length < 3) return triplets;

        Array.Sort(nums);

        int i = 0;
        while (i < nums.Length - 2)
        {
            var target = -1 * nums[i];
            var j = i + 1;
            var k = nums.Length - 1;

            while (j < k)
            {
                if (nums[j] + nums[k] > target)
                    k--;
                else if (nums[j] + nums[k] < target)
                    j++;
                else
                {
                    var triplet = new List<int>() { nums[i], nums[j], nums[k] };
                    triplets.Add(triplet);

                    // skip mid and end duplicates
                    while (j < k && nums[j] == triplet[1])
                        j++;
                    while (j < k && nums[k] == triplet[2])
                        k--;
                }
            }

            // skip target duplicates
            var skipVal = nums[i];
            while (i < nums.Length - 2 && nums[i] == skipVal)
                i++;
        }
        return triplets;
    }
}
