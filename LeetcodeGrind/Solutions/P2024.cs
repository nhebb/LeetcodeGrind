namespace LeetcodeGrind.Solutions;

// 2024. Maximize the Confusion of an Exam
public class P2024
{
    public int MaxConsecutiveAnswers(string answerKey, int k)
    {
        var t = 0;
        var f = 0;

        if (answerKey[0] == 'T')
            t++;
        else
            f++;
        var maxConseq = 1;

        var i = 0;
        var j = 1;
        while (j < answerKey.Length)
        {
            if (answerKey[j] == 'T')
                t++;
            else
                f++;

            if (Math.Min(t, f) > k)
            {
                if (answerKey[i] == 'T')
                    t--;
                else
                    f--;
                i++;
            }
            else
            {
                var conseq = j - i + 1;
                maxConseq = Math.Max(maxConseq, conseq);
            }
            j++;
        }

        return maxConseq;
    }
}
