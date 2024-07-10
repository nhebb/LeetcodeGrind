namespace LeetcodeGrind.Solutions;

// 1023. Camelcase Matching
public class P1023
{
    public IList<bool> CamelMatch(string[] queries, string pattern)
    {
        var result = new List<bool>(queries.Length);

        foreach (var query in queries)
        {
            var valid = true;
            var i = 0;
            var j = 0;
            while (i < query.Length && j < pattern.Length)
            {
                if (pattern[j] == query[i])
                {
                    i++;
                    j++;
                }
                else if (char.IsUpper(query[i]))
                {
                    valid = false;
                    break;
                }
                else
                {
                    i++;
                }
            }

            if (j < pattern.Length ||
               (i < query.Length && query[i..].Any(c => char.IsUpper(c))))
            {
                valid = false;
            }

            result.Add(valid);
        }

        return result;
    }
}
