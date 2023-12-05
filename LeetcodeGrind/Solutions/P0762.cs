namespace LeetcodeGrind.Solutions;

// 762. Prime Number of Set Bits in Binary Representation
public class P0762
{
    public int CountPrimeSetBits(int left, int right)
    {
        // int's are 32 bits, so we can just create a list of them
        var primes = new HashSet<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };

        var count = 0;

        for (uint i = (uint)left; i <= right; i++)
        {
            var bits = System.Numerics.BitOperations.PopCount(i);
            if (primes.Contains(bits))
            {
                //Console.WriteLine($"{i} -> {bits}");
                count++;
            }
        }

        return count;
    }
}
