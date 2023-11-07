namespace LeetcodeGrind.Solutions;

// 904. Fruit Into Baskets
public class P0904
{
    public int TotalFruit(int[] fruits)
    {
        var maxCount = 0;
        var i = 0;
        var j = 0;

        var d = new Dictionary<int, int>();

        while (i < fruits.Length)
        {
            if (d.Count <= 2)
            {
                if (!d.TryAdd(fruits[i], 1))
                    d[fruits[i]]++;
            }

            // remove begining fruits until only 2 keys (baskets)
            // remain in dictionary
            while (d.Count > 2)
            {
                if (d.ContainsKey(fruits[j]))
                {
                    d[fruits[j]]--;

                    if (d[fruits[j]] == 0)
                        d.Remove(fruits[j]);
                }
                j++;
            }

            maxCount = Math.Max(d.Values.Sum(), maxCount);
            i++;
        }

        return maxCount;
    }
}
