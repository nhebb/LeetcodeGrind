namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ah = new ArraysAndHashing.ArraysAndHashing();
            var arr = new int[] { 4, 0, 3, 0 };
            var res = ah.FindOriginalArray2(arr);


            Console.WriteLine($"[{string.Join(",", res)}]");

        }
    }
}