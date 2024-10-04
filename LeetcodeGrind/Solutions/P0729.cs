namespace LeetcodeGrind.Solutions;

// 729. My Calendar I
public class MyCalendar
{
    List<int> starts;
    List<int> ends;

    public MyCalendar()
    {
        // Make parallel lists so I can use built-in
        // BinarySearch on start. Capacity = 1000 is
        // the max number of calls per the constraints.
        starts = new List<int>(1000);
        ends = new List<int>(1000);
    }

    public bool Book(int start, int end)
    {
        var index = starts.BinarySearch(start);
        if (index >= 0)
        {
            return false;
        }

        index = ~index;

        if ((index > 0 && start < ends[index - 1]) || 
            (index < starts.Count && end > starts[index]))
        {
            return false;
        }

        starts.Insert(index, start);
        ends.Insert(index, end);

        return true;
    }
}