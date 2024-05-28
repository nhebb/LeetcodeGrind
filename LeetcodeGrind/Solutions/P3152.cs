namespace LeetcodeGrind.Solutions;

// 3152. Special Array II
public class P3152
{
    public bool[] IsArraySpecial(int[] nums, int[][] queries)
    {
        var counts = new int[nums.Length];
        counts[0] = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] % 2 == nums[i - 1] % 2)
            {
                counts[i] = counts[i - 1] + 1;
            }
            else
            {
                counts[i] = counts[i - 1];
            }
        }

        var answer = new bool[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            var from = queries[i][0];
            var to = queries[i][1];
            answer[i] = counts[to] - counts[from] == 0;
        }

        return answer;
    }
}
