namespace LeetcodeGrind.Solutions;

// 2079. Watering Plants
public class P2079
{
    public int WateringPlants(int[] plants, int capacity)
    {
        var count = 0;
        var water = capacity;

        for (int i = 0; i < plants.Length; i++)
        {
            // walk to plant and water it
            count += i + 1;
            water -= plants[i];

            // while water can has enough to fill neighnoring plant(s)
            // increment count, i, and water the plant(s)
            while (i < plants.Length - 1 && water >= plants[i + 1])
            {
                count++;
                i++;
                water -= plants[i];
            }

            // walk back to river and refill can
            count += i + 1;
            water = capacity;
        }

        return count;
    }
}
