namespace LeetcodeGrind.Solutions.P0528;

// 528. Random Pick with Weight
public class Solution
{
    private int[] _prefixSum;
    private Random _random;

    public Solution(int[] w)
    {
        _prefixSum = new int[w.Length];
        _prefixSum[0] = w[0];
        for (int i = 1; i < w.Length; i++)
        {
            _prefixSum[i] = w[i] + _prefixSum[i - 1];
        }
        _prefixSum[^1] += 1;

        _random = new Random();
    }

    public int PickIndex()
    {
        var weight = _random.Next(0, _prefixSum[^1]);

        var index = Array.BinarySearch(_prefixSum, weight);

        if (index < 0)
        {
            index = ~index;
        }

        return index;
    }
}
