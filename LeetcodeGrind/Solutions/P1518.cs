namespace LeetcodeGrind.Solutions;

// 1518. Water Bottles
public class P1518
{
    public int NumWaterBottles(int numBottles, int numExchange)
    {
        var consumed = 0;
        var empties = 0;

        while (numBottles + empties >= numExchange)
        {
            // Drink the bottles;
            consumed += numBottles;

            // Add them to empties
            empties += numBottles;

            // Exchange the bottles
            numBottles = empties / numExchange;

            // Calculate remaining empties after exchange
            empties %= numExchange;
        }

        // Drink any remaining bottles
        consumed += numBottles;

        return consumed;
    }
}
