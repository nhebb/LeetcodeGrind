namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var piles = new int[] {4,3,6,7};
            var k = 3;
            var h = new Heaps.Heaps();
            var sum = h.MinStoneSum(piles, k);
            Console.WriteLine(sum);
        }
    }
}