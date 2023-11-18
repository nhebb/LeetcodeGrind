namespace LeetcodeGrind.Solutions;

// 811. Subdomain Visit Count
public class P0811
{
    public IList<string> SubdomainVisits(string[] cpdomains)
    {
        var d = new Dictionary<string, int>();

        foreach (var cpdomain in cpdomains)
        {
            var parts = cpdomain.Split(" ");
            var count = int.Parse(parts[0]);
            var domain = parts[1];

            if(d.ContainsKey(domain))
                d[domain] += count;
            else 
                d[domain] = count;

            var idx = domain.IndexOf('.');
            while (idx > 0)
            {
                domain = domain.Substring(idx + 1);

                if (d.ContainsKey(domain))
                    d[domain] += count;
                else
                    d[domain] = count;

                idx = domain.IndexOf('.');
            }
        }

        var result = new List<string>();
        foreach (var kvp in d)
        {
            result.Add($"{kvp.Value} {kvp.Key}");
        }

        return result;
    }
}
