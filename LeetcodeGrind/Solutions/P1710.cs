namespace LeetcodeGrind.Solutions;

// 1710. Maximum Units on a Truck
public class P1710
{
    public int MaximumUnits(int[][] boxTypes, int truckSize)
    {
        Array.Sort(boxTypes, (a, b) => b[1] - a[1]);

        var totalBoxes = 0;
        var units = 0;
        for (int i = 0; i < boxTypes.Length; i++)
        {
            var numBoxes = boxTypes[i][0];
            var unitsPerBox = boxTypes[i][1];
            while (numBoxes > 0 && totalBoxes < truckSize)
            {
                units += unitsPerBox;
                totalBoxes++;
                numBoxes--;
            }

            if (totalBoxes == truckSize)
            {
                break;
            }
        }

        return units;
    }
}
