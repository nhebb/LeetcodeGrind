namespace LeetcodeGrind.Solutions;

// 3295. Report Spam Message
public class P3295
{
    public bool ReportSpam(string[] message, string[] bannedWords)
    {
        Array.Sort(message);
        Array.Sort(bannedWords);

        var i = 0;
        var j = 0;
        var count = 0;

        while (i < message.Length && j < bannedWords.Length)
        {
            var compared = message[i].CompareTo(bannedWords[j]);
            if (compared == 0)
            {
                count++;
                if (count == 2)
                    break;
            }
            else if (compared == -1)
            {
                i++;
            }
            else
            {
                j++;
            }

        }

        return count == 2;
    }

    // Much faster
    public bool ReportSpam2(string[] message, string[] bannedWords)
    {
        var banned = bannedWords.ToHashSet();
        var count = 0;

        for (int i = 0; i < message.Length; i++)
        {
            if (banned.Contains(message[i]))
            {
                count++;
                if (count == 2)
                    return true;
            }
        }

        return false;
    }
}
