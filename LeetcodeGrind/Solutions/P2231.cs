namespace LeetcodeGrind.Solutions;

// 2231. Largest Number After Digit Swaps by Parity
public class P2231
{
    public int LargestInteger(int num)
    {
        var sNum = num.ToString();
        var evenParity = new bool[sNum.Length];
        var pqEven = new PriorityQueue<int, int>();
        var pqOdd = new PriorityQueue<int, int>();

        for (int i = 0; i < sNum.Length; i++)
        {
            var val = sNum[i] - '0';
            if (val % 2 == 0)
            {
                evenParity[i] = true;
                pqEven.Enqueue(val, -val);
            }
            else
            {
                pqOdd.Enqueue(val, -val);
            }
        }

        var result = 0;
        for (int i = 0; i < sNum.Length; i++)
        {
            result *= 10;
            if (evenParity[i])
                result += pqEven.Dequeue();
            else
                result += pqOdd.Dequeue();
        }

        return result;
    }
}
