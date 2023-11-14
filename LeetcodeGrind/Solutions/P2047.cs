namespace LeetcodeGrind.Solutions;

// 2047. Number of Valid Words in a Sentence
public class P2047
{
    public int CountValidWords(string sentence)
    {
        var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var count = 0;

        foreach (var w in words)
        {
            bool valid = true;
            var hyphens = 0;
            var punctuation = 0;

            for (int i = 0; i < w.Length; i++)
            {
                if (char.IsDigit(w[i]))
                {
                    valid = false;
                    break;
                }
                else if (w[i] == '-')
                {
                    hyphens++;
                    if (hyphens > 1 | i == 0 || i == w.Length - 1
                        || !char.IsLetter(w[i - 1]) || !char.IsLetter(w[i + 1]))
                    {
                        valid = false;
                        break;
                    }
                }
                else if (w[i] == '.' || w[i] == ',' || w[i] == '!')
                {
                    punctuation++;
                    if (punctuation > 1 || i != w.Length - 1)
                    {
                        valid = false;
                        break;
                    }
                }
                else if (!char.IsLetter(w[i]))
                {
                    valid = false;
                    break;
                }
            }

            if (valid)
            {
                count++;
            }
        }

        return count;
    }
}
