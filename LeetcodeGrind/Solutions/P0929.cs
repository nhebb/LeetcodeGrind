namespace LeetcodeGrind.Solutions;

// 929. Unique Email Addresses
public class P0929
{
    public int NumUniqueEmails(string[] emails)
    {
        var hs = new HashSet<string>();
        foreach (var email in emails)
        {
            var parts = email.Split('@');
            var local = parts[0].Replace(".", "");
            if (local.Contains('+'))
                hs.Add(local.Split('+')[0] + "@" + parts[1]);
            else
                hs.Add(local + "@" + parts[1]);
        }
        return hs.Count;
    }
}
