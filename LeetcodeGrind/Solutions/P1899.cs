namespace LeetcodeGrind.Solutions;

// 1899. Merge Triplets to Form Target Triplet
public class P1899
{
    public bool MergeTriplets(int[][] triplets, int[] target)
    {
        var first = new List<IList<int>>();
        var second = new List<IList<int>>();
        var third = new List<IList<int>>();

        for (int i = 0; i < triplets.Length; i++)
        {
            if (triplets[i][0] == target[0] &&
                triplets[i][1] <= target[1] &&
                triplets[i][2] <= target[2])
            {
                first.Add(triplets[i]);
            }
            if (triplets[i][0] <= target[0] &&
                triplets[i][1] == target[1] &&
                triplets[i][2] <= target[2])
            {
                second.Add(triplets[i]);
            }
            if (triplets[i][0] <= target[0] &&
                triplets[i][1] <= target[1] &&
                triplets[i][2] == target[2])
            {
                third.Add(triplets[i]);
            }
        }

        return first.Count > 0 &&
               second.Count > 0 &&
               third.Count > 0;
    }
}
