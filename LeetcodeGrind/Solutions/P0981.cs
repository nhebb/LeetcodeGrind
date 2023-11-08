namespace LeetcodeGrind.Solutions;

// 981. Time Based Key-Value Store
/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */
public class TimeMap
{
    private class TimeItem
    {
        public int Timestamp { get; private set; }
        public string Value { get; private set; }

        public TimeItem(string value, int timestamp)
        {
            Value = value;
            Timestamp = timestamp;
        }
    }

    Dictionary<string, List<TimeItem>> timeVals;

    public TimeMap()
    {
        timeVals = new Dictionary<string, List<TimeItem>>();
    }

    public void Set(string key, string value, int timestamp)
    {
        var item = new TimeItem(value, timestamp);

        if (timeVals.ContainsKey(key))
            timeVals[key].Add(item);
        else
            timeVals[key] = new List<TimeItem> { item };
    }

    public string Get(string key, int timestamp)
    {
        if (timeVals.TryGetValue(key, out var list))
        {
            return BinarySearch(list, timestamp);
        }
        else
        {
            return "";
        }
    }

    private string BinarySearch(List<TimeItem> list, int timestamp)
    {
        if (list[0].Timestamp > timestamp)
            return "";

        string Search(int low, int high)
        {
            if (high == low)
                return list[low].Value;

            if (high - low == 1)
                return list[high].Timestamp <= timestamp
                    ? list[high].Value
                    : list[low].Value;

            var mid = low + (high - low) / 2;

            if (list[mid].Timestamp == timestamp)
                return list[mid].Value;
            else if (list[mid].Timestamp < timestamp)
                return Search(mid + 1, high);
            else
                return Search(low, mid - 1);
        }

        return Search(0, list.Count - 1);
    }
}