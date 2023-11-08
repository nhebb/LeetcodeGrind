namespace LeetcodeGrind.Solutions;

// 46. Permutations
public class P0046
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var permutations = new List<IList<int>>();
        var permutation = new List<int>();
        var chosen = new bool[nums.Length];

        void Backtrack()
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (chosen[i])
                    continue;

                permutation.Add(nums[i]);
                if (permutation.Count == nums.Length)
                {
                    permutations.Add(new List<int>(permutation));
                }
                else
                {
                    chosen[i] = true;
                    Backtrack();
                    chosen[i] = false;
                }
                permutation.RemoveAt(permutation.Count - 1);
            }
        }

        Backtrack();
        return permutations;
    }
}
