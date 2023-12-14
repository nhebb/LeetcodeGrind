namespace LeetcodeGrind.Solutions;

// 1455. Check If a Word Occurs As a Prefix of Any Word in a Sentence
public class P1455
{
    public int IsPrefixOfWord(string sentence, string searchWord)
    {
        var words = sentence.Split(' ');
        
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].StartsWith(searchWord))
            {
                return i + 1;
            }
        }

        return -1;
    }
}
