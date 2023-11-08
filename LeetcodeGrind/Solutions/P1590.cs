namespace LeetcodeGrind.Solutions;

// 1590. Make Sum Divisible by P
public class P1590
{
    public int MinSubarray(int[] nums, int p)
    {
        // The goal is to remove a minimal subarray that makes the remaining 
        // array sum divisible by p. Take the total and calculate the 
        // remainder => nums.Sum() % p. The subarray must sum to 
        // remainder + x * p, where x is unknown.

        // Calculate the remainder for the total sum by adding
        // each num and taking the modulus. (Prevents overflow.)
        var overallRemainder = 0;
        foreach (int num in nums)
            overallRemainder = (overallRemainder + num) % p;

        if (overallRemainder == 0)
            return 0;

        // Calculate the running prefix sum for each position the same way
        // we calculated the overall remainder. Store the mod value in a hash table
        // with the index.
        var modToIndexMap = new Dictionary<int, int>();

        var minLen = nums.Length;
        var remainder = 0;
        modToIndexMap[remainder] = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            remainder = (remainder + nums[i]) % p;

            // We are working left to right, so it's ok to overwrite the
            // last value since we want the nearest index to our current position
            modToIndexMap[remainder] = i;

            // Subtract the overall remainder from the current remainder, then
            // add p to ensure it's > 0. Then, take the modulus so the value
            // 0 <= key < p
            int key = (remainder - overallRemainder + p) % p;

            // When a matching key is found, it indicates that the subarray
            // between the indices sums to remainder + x * p
            if (modToIndexMap.ContainsKey(key))
                minLen = Math.Min(minLen, i - modToIndexMap[key]);
        }

        return minLen == nums.Length ? -1 : minLen;
    }
}
