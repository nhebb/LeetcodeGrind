namespace LeetcodeGrind.Solutions;

// 1227. Airplane Seat Assignment Probability
public class P1227
{
    // Math problem masquerading as a programming problem.
    public double NthPersonGetsNthSeat(int n)
    {
        return n == 1 ? 1.0 : 0.5;
    }
}
