using System.Text;

namespace LeetcodeGrind.Solutions;

// 3163. String Compression III
public class P3163
{
    public string CompressedString(string word)
    {
        var lastChar = word[0];
        var count = 1;
        var comp = new StringBuilder();

        for (int i = 1; i < word.Length; i++)
        {
            if (word[i] == lastChar)
            {
                count++;
            }
            else
            {
                while (count > 9)
                {
                    comp.Append(9).Append(lastChar);
                    count -= 9;
                }
                comp.Append(count).Append(lastChar);

                lastChar = word[i];
                count = 1;
            }
        }

        while (count > 9)
        {
            comp.Append(9).Append(lastChar);
            count -= 9;
        }
        comp.Append(count).Append(lastChar);

        return comp.ToString();
    }
}
