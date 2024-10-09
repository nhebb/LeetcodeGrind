namespace LeetcodeGrind.Solutions;

// 1813. Sentence Similarity III
public class P1813
{
    public bool AreSentencesSimilar(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            (s1, s2) = (s2, s1);

        var words1 = s1.Split(' ');
        var words2 = s2.Split(' ');

        var i1 = 0;
        var j1 = words1.Length - 1;
        var i2 = 0;
        var j2 = words2.Length - 1;

        while (i1 < words1.Length && words1[i1] == words2[i2])
        {
            i1++;
            i2++;
        }
        while (j1 >= 0 && words1[j1] == words2[j2])
        {
            j1--;
            j2--;
        }

        return i1 > j1;
    }
}
