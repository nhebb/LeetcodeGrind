namespace LeetcodeGrind.Solutions;

// 2037. Minimum Number of Moves to Seat Everyone
public class P2037
{
    public int MinMovesToSeat(int[] seats, int[] students)
    {
        Array.Sort(seats);
        Array.Sort(students);

        var moves = 0;
        for (int i = 0; i < seats.Length; i++)
        {
            moves += Math.Abs(students[i] - seats[i]);
        }

        return moves;
    }
}
