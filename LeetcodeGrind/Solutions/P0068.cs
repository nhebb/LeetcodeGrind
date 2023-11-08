using System.Text;

namespace LeetcodeGrind.Solutions;

// 68. Text Justification
public class P0068
{
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        var result = new List<string>();
        var lines = new List<(IList<string> items, int len)>();
        for (int i = 0; i < words.Length; i++)
        {
            var line = new List<string>();
            var lineLength = 0;
            var spaces = 0;
            var j = i;
            while (j < words.Length && words[j].Length + spaces + lineLength < maxWidth)
            {
                line.Add(words[j]);
                lineLength += words[j].Length;
                spaces++;
                j++;
            }
            lines.Add((line, lineLength));
            i = j - 1; // backstep to account for i increment
        }

        // handle lines up to last line
        var sb = new StringBuilder();
        for (int i = 0; i < lines.Count - 1; i++)
        {
            var len = lines[i].len;
            var items = lines[i].items;

            if (items.Count == 1)
            {
                sb.Append(items[0]);
                sb.Append(new String(' ', maxWidth - len));
            }
            else
            {
                var numGaps = items.Count - 1;
                var totalSpaces = maxWidth - len;
                var gapWidth = totalSpaces / numGaps;
                var extraSpaces = totalSpaces % numGaps;
                var padding = new String(' ', gapWidth);

                for (int j = 0; j < items.Count; j++)
                {
                    sb.Append(items[j]);
                    if (j < items.Count - 1)
                    {
                        sb.Append(padding);
                        if (extraSpaces > 0)
                        {
                            sb.Append(' ');
                            extraSpaces--;
                        }
                    }
                }
            }
            result.Add(sb.ToString());
            sb.Clear();
        }

        // handle last line
        sb.Append(string.Join(' ', lines[^1].items));
        var rightPadding = maxWidth - sb.Length;
        sb.Append(new string(' ', rightPadding));
        result.Add(sb.ToString());

        return result;
    }
}
