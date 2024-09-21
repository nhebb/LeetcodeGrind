namespace LeetcodeGrind.Solutions;

// 386. Lexicographical Numbers
public class P0386
{
    public IList<int> LexicalOrder(int n)
    {
        return Enumerable.Range(1, n)
                         .OrderBy(x => x.ToString())
                         .ToList();
    }
}
