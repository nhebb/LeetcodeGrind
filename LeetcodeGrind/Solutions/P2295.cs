namespace LeetcodeGrind.Solutions;

// 2295. Replace Elements in an Array
public class P2295
{
    public int[] ArrayChange(int[] nums, int[][] operations)
    {
        var d = new Dictionary<int, HashSet<int>>();
        var res = new int[nums.Length];
        Array.Copy(nums, res, nums.Length);

        for (int i = 0; i < nums.Length; i++)
        {
            if (!d.ContainsKey(nums[i]))
                d[nums[i]] = new HashSet<int>();
            d[nums[i]].Add(i);
        }

        foreach (var operation in operations)
        {
            var indices = d[operation[0]];
            foreach (var index in indices)
            {
                res[index] = operation[1];
                if (!d.ContainsKey(res[index]))
                    d[res[index]] = new HashSet<int>();
                d[res[index]].Add(index);
                d[operation[0]].Remove(index);
            }
        }
        return res;
    }
}
