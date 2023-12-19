namespace LeetcodeGrind.Solutions;

// 2899. Last Visited Integers
public class P2899
{
    public IList<int> LastVisitedIntegers(IList<string> words)
    {
        var numsReverse = new List<int>();
        var prevCount = 0;
        var result = new List<int>();

        for (int i = 0; i < words.Count; i++)
        {
            if (words[i] == "prev")
            {
                prevCount++;
                var index = numsReverse.Count - prevCount;
                result.Add(index >= 0 ? numsReverse[index] : -1);
            }
            else
            {
                numsReverse.Add(int.Parse(words[i]));
                prevCount = 0;
            }
        }

        return result;
    }
}
