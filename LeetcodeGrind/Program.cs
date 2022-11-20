namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 1000000000, 1000000000, 1000000000, 1000000000};
            var target = -294967296;
            var aah = new ArraysAndHashing.ArraysAndHashing();
            Console.WriteLine("Result: " + aah.FourSum(nums, target).ToString());
        }

        // From https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
        private static void ShowRangeExamples()
        {
            int[] numbers = Enumerable.Range(0, 100).ToArray();
            Console.WriteLine($"The last value of Enumerable.Range(0, 100) is {numbers[^1]}");

            int x = 12;
            int y = 25;
            int z = 36;

            Console.WriteLine($"{numbers[^x]} is the same as {numbers[numbers.Length - x]}");
            Console.WriteLine($"{numbers[x..y].Length} is the same as {y - x}");

            Console.WriteLine("numbers[x..y] and numbers[y..z] are consecutive and disjoint:");
            Span<int> x_y = numbers[x..y];
            Span<int> y_z = numbers[y..z];
            Console.WriteLine($"\tnumbers[x..y] is {x_y[0]} through {x_y[^1]}, numbers[y..z] is {y_z[0]} through {y_z[^1]}");

            Console.WriteLine("numbers[x..^x] removes x elements at each end:");
            Span<int> x_x = numbers[x..^x];
            Console.WriteLine($"\tnumbers[x..^x] starts with {x_x[0]} and ends with {x_x[^1]}");

            Console.WriteLine("numbers[..x] means numbers[0..x] and numbers[x..] means numbers[x..^0]");
            Span<int> start_x = numbers[..x];
            Span<int> zero_x = numbers[0..x];
            Console.WriteLine($"\t{start_x[0]}..{start_x[^1]} is the same as {zero_x[0]}..{zero_x[^1]}");
            Span<int> z_end = numbers[z..];
            Span<int> z_zero = numbers[z..^0];
            Console.WriteLine($"\t{z_end[0]}..{z_end[^1]} is the same as {z_zero[0]}..{z_zero[^1]}");

        }
    }
}