namespace LeetcodeGrind.Solutions;

// 933. Number of Recent Calls
public class RecentCounter
{

    List<int> _requests;

    public RecentCounter()
    {
        _requests = new List<int>();
    }

    public int Ping(int t)
    {
        _requests.Add(t);
        var index = _requests.BinarySearch(t - 3000);
        if (index < 0)
            index = ~index;
        return _requests.Count - index;
    }
}