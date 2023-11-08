namespace LeetcodeGrind.Solutions;

// 146. LRU Cache
public class LRUCache
{
    private int _capacity;
    private LinkedList<int[]> _cache;
    private Dictionary<int, LinkedListNode<int[]>> _cacheMap;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new LinkedList<int[]>();
        _cacheMap = new Dictionary<int, LinkedListNode<int[]>>();
    }

    public int Get(int key)
    {
        if (!_cacheMap.ContainsKey(key))
            return -1;
        var node = _cacheMap[key];
        var result = node.Value[1];
        _cache.Remove(node);
        _cache.AddLast(node);
        return result;
    }

    public void Put(int key, int value)
    {
        if (_cacheMap.ContainsKey(key))
        {
            var node = _cacheMap[key];
            node.Value[1] = value;
            _cache.Remove(node);
            _cache.AddLast(node);
        }
        else
        {
            // Node value is an integer array. Index 0 contains the key
            // and index 1 contains the value.
            var node = new LinkedListNode<int[]>(new int[] { key, value });
            _cacheMap[key] = node;
            _cache.AddLast(node);

            if (_cache.Count > _capacity)
            {
                var lruNode = _cache.First;
                _cache.RemoveFirst();
                if (lruNode != null)
                {
                    var lruKey = lruNode.Value[0];
                    _cacheMap.Remove(lruKey);
                }
            }
        }
    }
}