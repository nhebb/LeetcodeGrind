namespace LeetcodeGrind.Solutions;

// TODO: 731. My Calendar II
public class MyCalendarTwo
{
    List<bool> doubleBooked;
    List<int> starts;
    List<int> ends;

    public MyCalendarTwo()
    {
        // Make parallel lists so I can use built-in
        // BinarySearch on start. Capacity = 1000 is
        // the max number of calls per the constraints.
        doubleBooked = new List<bool>();
        starts = new List<int>(1000);
        ends = new List<int>(1000);
    }

    public bool Book(int start, int end)
    {
        var index = starts.BinarySearch(start);
        if (index >= 0)
        {
            if (doubleBooked[index])
            {
                return false;
            }

            doubleBooked[index] = true;
            if (end > ends[index])
            {
                index++;
            }

            doubleBooked.Insert(index, true);
            starts.Insert(index, start);
            ends.Insert(index, end);

            return true;
        }

        index = ~index;

        if (index > 0 && start < ends[index - 1])
        {
            if (doubleBooked[index - 1])
            {
                return false;
            }

            doubleBooked[index - 1] = true;
            if (end > ends[index - 1])
            {
                doubleBooked.Insert(index, true);
                starts.Insert(index, start);
                ends.Insert(index, end);
            }
        }
        else if (index < starts.Count && end > starts[index])
        {
            if (doubleBooked[index])
            {
                return false;
            }

            doubleBooked[index] = true;

            if (start < starts[index])
            {
                doubleBooked.Insert(index, true);
                starts.Insert(index, start);
                ends.Insert(index, end);
            }
            // else: new interval is encompassed by next interval,
            // therefore no new interval needs to be added - just
            // mark next as double booked
        }
        else
        {
            // default: non-overlapping interval is added
            doubleBooked.Insert(index, false);
            starts.Insert(index, start);
            ends.Insert(index, end);
        }

        return true;
    }
}