namespace LeetcodeGrind.Solutions;

// 2526. Find Consecutive Integers from a Data Stream
public class DataStream
{
    int _value;
    int _k;
    int _count;

    public DataStream(int value, int k)
    {
        _value = value;
        _k = k;
        _count = 0;
    }

    public bool Consec(int num)
    {
        if (num == _value)
            _count++;
        else
            _count = 0;

        return _count >= _k;
    }
}