namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[1][];
            matrix[0] = new int[] { 1, 1 };
            var target = 2;
            var bs = new BinarySearch.BinarySearch();
            var result = bs.SearchMatrix(matrix, target);
            Console.WriteLine("Expected: false");
            Console.WriteLine($"Result: {result}");
        }
    }
}