namespace LeetcodeGrind.Solutions;

// 2284. Sender With Largest Word Count
public class P2284
{
    public string LargestWordCount(string[] messages, string[] senders)
    {
        var maxWords = 0;
        var bigSenders = new List<string>();
        var d = new Dictionary<string, int>();

        for (int i = 0; i < messages.Length; i++)
        {
            var numWords = messages[i].Split(' ').Length;
            if (d.TryGetValue(senders[i], out int val))
                numWords += val;
            d[senders[i]] = numWords;

            if (numWords == maxWords)
            {
                bigSenders.Add(senders[i]);
            }
            else if (numWords > maxWords)
            {
                bigSenders.Clear();
                bigSenders.Add(senders[i]);
                maxWords = numWords;
            }
        }

        return bigSenders.OrderByDescending(x => x, StringComparer.Ordinal)
                         .First();
    }
}
