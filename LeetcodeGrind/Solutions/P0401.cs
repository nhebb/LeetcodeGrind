namespace LeetcodeGrind.Solutions;

// 401. Binary Watch

public class P0401
{
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        var times = new List<string>();

        for (uint h = 0; h < 12; h++)
        {
            var hourBits = System.Numerics.BitOperations.PopCount(h);
            for (uint m = 0; m < 60; m++)
            {
                var bits = hourBits + System.Numerics.BitOperations.PopCount(m);
                if (bits == turnedOn)
                {
                    times.Add($"{h}:{m:D2}");
                }
            }
        }

        return times;
    }
}
