namespace LeetcodeGrind.Solutions;

// 2490. Circular Sentence
public class P2490
{
    public bool IsCircularSentence(string sentence)
    {
        var words = sentence.Split(' ');
        for (int i = 0; i < words.Length - 1; i++)
        {
            if (words[i][^1] != words[i + 1][0])
                return false;
        }
        return words[0][0] == words[^1][^1];
    }
}
