namespace LeetcodeGrind.Solutions;

// 2353. Design a Food Rating System
public class FoodRatings
{

    class FoodComparer : IComparer<(int rating, string food)>
    {
        public int Compare((int rating, string food) a, (int rating, string food) b)
        {
            if (a.rating > b.rating)
            {
                return 1;
            }
            else if (a.rating < b.rating)
            {
                return -1;
            }
            else
            {
                return b.food.CompareTo(a.food);
            }
        }
    }

    private Dictionary<string, SortedSet<(int rating, string food)>> _cuisineFoodSets;
    private Dictionary<string, int> _foodRatings;
    private Dictionary<string, string> _foodCuisines;

    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        _cuisineFoodSets = new();
        _foodRatings = new();
        _foodCuisines = new();

        for (int i = 0; i < foods.Length; i++)
        {
            _foodRatings[foods[i]] = ratings[i];
            _foodCuisines[foods[i]] = cuisines[i];
            if (_cuisineFoodSets.ContainsKey(cuisines[i]))
            {
                _cuisineFoodSets[cuisines[i]].Add((ratings[i], foods[i]));
            }
            else
            {
                var foodSet = new SortedSet<(int rating, string food)>(new FoodComparer());
                foodSet.Add((ratings[i], foods[i]));
                _cuisineFoodSets.Add(cuisines[i], foodSet);
            }
        }
    }

    public void ChangeRating(string food, int newRating)
    {
        if (_foodRatings.ContainsKey(food))
        {
            var oldRating = _foodRatings[food];
            _foodRatings[food] = newRating;
            var cuisine = _foodCuisines[food];
            var foodSet = _cuisineFoodSets[cuisine];

            foodSet.Remove((oldRating, food));
            foodSet.Add((newRating, food));
        }
    }

    public string HighestRated(string cuisine)
    {
        var foodSet = _cuisineFoodSets[cuisine].Max;
        return foodSet.food;
    }
}