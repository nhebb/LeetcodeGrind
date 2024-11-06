namespace LeetcodeGrind.Solutions;

// 3011. Find if Array Can Be Sorted
public class P3011
{
    public bool CanSortArray(int[] nums)
    {
        var bitCounts = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            bitCounts[i] = int.PopCount(nums[i]);
        }

        var startIndex = 0;
        var temp = new List<int>();
        temp.Add(nums[0]);

        for (int i = 1; i < nums.Length; i++)
        {
            if (bitCounts[i] == bitCounts[i - 1])
            {
                temp.Add(nums[i]);
            }
            else
            {
                if (temp.Count > 1)
                {
                    temp.Sort();
                    var j = startIndex;
                    for (int k = 0; k < temp.Count; j++, k++)
                    {
                        nums[j] = temp[k];
                    }
                }

                temp.Clear();
                temp.Add(nums[i]);
                startIndex = i;
            }
        }

        // sort final temp entries
        if (temp.Count > 1)
        {
            temp.Sort();
            var j = startIndex;
            for (int k = 0; k < temp.Count; j++, k++)
            {
                nums[j] = temp[k];
            }
        }

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] > nums[i + 1])
            {
                return false;
            }
        }

        return true;
    }
}
