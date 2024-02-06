namespace LeetcodeGrind.Solutions;

// 284. Peeking Iterator
class PeekingIterator
{
    IEnumerator<int> _iterator;
    bool _hasNext;

    public PeekingIterator(IEnumerator<int> iterator)
    {
        _iterator = iterator;
        _hasNext = true;
    }

    public int Peek()
    {
        return _iterator.Current;
    }

    public int Next()
    {
        var next = _iterator.Current;
        _hasNext = _iterator.MoveNext();
        return next;
    }

    public bool HasNext()
    {
        return _hasNext;
    }
}