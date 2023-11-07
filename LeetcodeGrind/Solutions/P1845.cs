namespace LeetcodeGrind.Solutions;

// 1845. Seat Reservation Manager
public class SeatManager
{
    private PriorityQueue<int, int> _pq;

    public SeatManager(int n)
    {
        _pq = new PriorityQueue<int, int>(n);
        for (int i = 1; i <= n; i++)
        {
            _pq.Enqueue(i, i);
        }
    }

    public int Reserve()
    {
        return _pq.Dequeue();
    }

    public void Unreserve(int seatNumber)
    {
        _pq.Enqueue(seatNumber, seatNumber);
    }
}
