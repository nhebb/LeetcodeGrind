namespace LeetcodeGrind.Solutions;

// 2125. Number of Laser Beams in a Bank
public class P2125
{
    public int NumberOfBeams(string[] bank)
    {
        var devices = new List<int>();
        for (int i = 0; i < bank.Length; i++)
        {
            var rowCount = bank[i].Count(x => x == '1');
            if (rowCount > 0)
                devices.Add(rowCount);
        }

        var count = 0;
        for (int i = 0; i < devices.Count - 1; i++)
        {
            count += devices[i] * devices[i + 1];
        }

        return count;
    }
}
