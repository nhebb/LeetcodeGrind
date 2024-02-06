namespace LeetcodeGrind.Solutions;

// 2013. Detect Squares
public class DetectSquares
{
    private Dictionary<(int, int), int> _pointCount;
    private List<(int x, int y)> _points;

    public DetectSquares()
    {
        _pointCount = new Dictionary<(int, int), int>();
        _points = new List<(int x, int y)>();
    }

    public void Add(int[] point)
    {
        var x = point[0];
        var y = point[1];

        _points.Add((x, y));

        if (_pointCount.ContainsKey((x, y)))
        {
            _pointCount[(x, y)]++;
        }
        else
        {
            _pointCount[(x, y)] = 1;
        }
    }

    public int Count(int[] point)
    {
        var x = point[0];
        var y = point[1];
        var count = 0;

        foreach (var pt in _points)
        {
            if (Math.Abs(pt.x - x) != Math.Abs(pt.y - y)
                || pt.x == x || pt.y == y)
            {
                continue;
            }

            if (_pointCount.ContainsKey((pt.x, y)) &&
                _pointCount.ContainsKey((x, pt.y)))
            {
                count += _pointCount[(pt.x, y)] *
                         _pointCount[(x, pt.y)];
            }
        }

        return count;
    }
}
