namespace LeetcodeGrind.Solutions;

// 2766. Relocate Marbles
public class P2766
{
    public IList<int> RelocateMarbles(int[] nums, int[] moveFrom, int[] moveTo)
    {
        var occupied = nums.ToHashSet();

        for (int i = 0; i < moveFrom.Length; i++)
        {
            
            occupied.Remove(moveFrom[i]);
            occupied.Add(moveTo[i]);
        }
        
        return occupied.OrderBy(x => x)
                       .ToList();
    }
}
