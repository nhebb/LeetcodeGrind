namespace LeetcodeGrind.Solutions;

// 2402. Meeting Rooms III
public class P2402
{
    private class RoomComparer : IComparer<(int available, int number)>
    {
        public int Compare((int available, int number) x, (int available, int number) y)
        {
            if (x.available < y.available)
            {
                return -1;
            }
            else if (x.available == y.available)
            {
                return x.number.CompareTo(y.number);
            }
            return 1;
        }
    }

    public int MostBooked(int n, int[][] meetings)
    {
        var unoccupied = new PriorityQueue<(int available, int number), (int, int)>(meetings.Length, new RoomComparer());
        var occupied = new PriorityQueue<(int available, int number), int>(meetings.Length);

        for (int i = 0; i < n; i++)
        {
            unoccupied.Enqueue((0, i), (0, i));
        }

        var counts = new int[n];
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        for (int i = 0; i < meetings.Length; i++)
        {
            while (occupied.Count > 0 && occupied.Peek().available <= meetings[i][0])
            {
                var newRoom = occupied.Dequeue();
                newRoom.available = meetings[i][0];
                unoccupied.Enqueue(newRoom, newRoom);
            }

            if (unoccupied.Count == 0)
            {
                var nextTime = occupied.Peek().available;
                while (occupied.Count > 0 && occupied.Peek().available <= nextTime)
                {
                    var nextRoom = occupied.Dequeue();
                    nextRoom.available = nextTime;
                    unoccupied.Enqueue(nextRoom, nextRoom);
                }
            }

            var room = unoccupied.Dequeue();
            counts[room.number]++;
            room.available = meetings[i][1];
            occupied.Enqueue(room, room.available);
        }

        var maxRoom = 0;
        var max = counts[0];
        for (int i = 1; i < counts.Length; i++)
        {
            if (counts[i] > max)
            {
                maxRoom = i;
                max = counts[i];
            }
        }

        return maxRoom;
    }


    public int MostBooked2(int n, int[][] meetings)
    {
        var count = new int[n];
        var occupied = new PriorityQueue<int, (long, int)>();
        var unoccupied = new PriorityQueue<int, int>(Enumerable.Range(0, n).Select(i => (i, i)));

        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        for (int i = 0; i < meetings.Length; i++)
        {
            while (occupied.TryPeek(out var r, out var p) && p.Item1 <= meetings[i][0])
            {
                unoccupied.Enqueue(r, r);
                occupied.Dequeue();
            }

            if (unoccupied.Count > 0)
            {
                var room = unoccupied.Dequeue();

                count[room]++;
                occupied.Enqueue(room, (meetings[i][1], room));
            }
            else
            {
                occupied.TryDequeue(out var room, out var end);

                count[room]++;
                occupied.Enqueue(room, (end.Item1 + meetings[i][1] - meetings[i][0], room));
            }
        }

        var max = 0;
        var maxRoom = 0;
        for (int i = 0; i < count.Length; i++)
        {
            if (count[i] > max)
            {
                max = count[i];
                maxRoom = i;
            }
        }

        return maxRoom;
    }
}
