namespace LeetcodeGrind.Solutions;

// 380. Insert Delete GetRandom O(1)
public class RandomizedSet
{
    private HashSet<int> _hs;
    private Random _random;

    public RandomizedSet()
    {
        _hs = new HashSet<int>();
        _random = new Random();
    }

    public bool Insert(int val)
    {
        return _hs.Add(val);
    }

    public bool Remove(int val)
    {
        return _hs.Remove(val);
    }

    public int GetRandom()
    {
        return _hs.ElementAt(_random.Next(_hs.Count - 1));
    }
}

