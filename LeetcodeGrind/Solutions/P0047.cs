namespace LeetcodeGrind.Solutions;

// 47. Permutations II
public class P0047
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var permutations = new List<IList<int>>();
        var hs = new HashSet<string>();
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
                    var hash = string.Join(" ", permutation);
                    if (hs.Add(hash))
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
