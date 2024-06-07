namespace LeetcodeGrind.Solutions;

// TODO: 1442. Count Triplets That Can Form Two Arrays of Equal XOR
public class P1442
{
    // WRONG ANSWER
    public int CountTriplets(int[] arr)
    {
        var xors = new int[arr.Length];
        xors[0] = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            xors[i] = arr[i] ^ xors[i - 1];
        }

        var d = new Dictionary<int, int>();
        for (int i = 0; i < arr.Length - 2; i++)
        {
            for (int j = i + 1; j < arr.Length - 1; j++)
            {
                for (int k = j + 1; k < arr.Length; k++)
                {
                    var a = xors[j - 1];
                    var b = xors[k] ^ a;
                    if (a != b)
                        continue;

                    if (d.TryGetValue(a, out int value))
                    {
                        d[a] = value + 2;
                    }
                    else
                    {
                        d[a] = 2;
                    }
                }
            }
        }

        var count = 0;
        foreach (var kvp in d)
        {
            if (kvp.Value > 1)
            {
                count += (kvp.Value * (kvp.Value - 1)) / 2;
            }
        }

        return count;
    }
}
