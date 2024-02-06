using System.Text;

namespace LeetcodeGrind.Solutions;

// 451. Sort Characters By Frequency
public class P0451
{
    public string FrequencySort(string s)
    {
        // Create a dictionary of character counts 
        var counts = s.GroupBy(c => c)
                      .ToDictionary(g => g.Key, g => g.Count())
                      .OrderByDescending(kvp => kvp.Value);

        // Iterate over key value pairs and add the character
        // to a StringBuilder.
        var sb = new StringBuilder();
        foreach (var kvp in counts)
        {
            for (int i = 0; i < kvp.Value; i++)
            {
                sb.Append(kvp.Key);
            }
        }

        return sb.ToString();
    }
}
