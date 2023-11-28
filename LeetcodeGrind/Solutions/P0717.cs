namespace LeetcodeGrind.Solutions;

// 717. 1-bit and 2-bit Characters
public class P0717
{
    public bool IsOneBitCharacter(int[] bits)
    {
        var i = 0;
        while (i < bits.Length - 1)
        {
            if (bits[i] == 1)
                i += 2;
            else
                i++;
        }

        if (i == bits.Length - 1 && bits[i] == 0)
            return true;

        return false;
    }
}
