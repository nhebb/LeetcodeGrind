namespace LeetcodeGrind.Solutions;

// 1217. Minimum Cost to Move Chips to The Same Position
public class P1217
{
    public int MinCostToMoveChips(int[] position)
    {
        var evens = position.Count(x => x % 2 == 0);
        var odds = position.Length - evens;

        return evens > odds
            ? odds
            : evens;
    }
}
