namespace LeetcodeGrind.Solutions;

// 2562. Find the Array Concatenation Value
public class P2562
{
    public long FindTheArrayConcVal(int[] nums)
    {
        var vals = new List<string>();
        var i = 0;
        var j = nums.Length - 1;

        while (i <= j)
        {
            if (i < j)
            {
                vals.Add(nums[i].ToString() + nums[j].ToString());
            }
            else
            {
                vals.Add(nums[i].ToString());
            }
            i++;
            j--;
        }

        long sum = 0;
        for (i = 0; i < vals.Count; i++)
        {
            sum += long.Parse(vals[i]);
        }

        return sum;
    }
}
