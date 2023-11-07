namespace LeetcodeGrind.Solutions;

// 292. Nim Game
public class P0292
{
    public bool CanWinNim(int n)
    {
        // Explanation: If there are 4 remaining sticks,
        // no matter how many you choose, the opponent
        // can always pick up the remainder and win.
        // If you follow the pattern out, any multiple
        // of 4 lets the opponent choose a number that
        // leaves you with another multiple of 4.
        return n % 4 != 0;
    }
}
