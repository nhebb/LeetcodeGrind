namespace LeetcodeGrind.Solutions;

// 1472. Design Browser History
public class BrowserHistory
{
    Stack<string> _back;
    Stack<string> _forward;
    string _current;

    public BrowserHistory(string homepage)
    {
        _back = new();
        _forward = new();
        _current = homepage;
    }

    public void Visit(string url)
    {
        if (_current != url)
            _back.Push(_current);
        _forward.Clear();
        _current = url;
    }

    public string Back(int steps)
    {
        while (_back.Count > 0 && steps > 0)
        {
            _forward.Push(_current);
            _current = _back.Pop();
            steps--;
        }
        return _current;
    }

    public string Forward(int steps)
    {
        while (_forward.Count > 0 && steps > 0)
        {
            _back.Push(_current);
            _current = _forward.Pop();
            steps--;
        }
        return _current;
    }
}
