namespace AdventOfCode2025.Days.Day5;

internal class Part2 : DayPart
{
    //public override bool HasPrecedence => true;
    //public override string InputFile => "Example.txt";
    public override bool ShouldRejectWhiteSpaceLines => false;

    public override void Run(List<string> input)
    {
        List<FreshIngredients> freshIngredientsList = [];
        List<long> availableIngredients = [];

        bool switched = false;
        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                switched = true;
            }
            else
            {
                if (switched)
                {
                    availableIngredients.Add(long.Parse(line));
                }
                else
                {
                    freshIngredientsList.Add(FreshIngredients.Parse(line));
                }
            }
        }

        List<FreshIngredients> accumulated = [];
        List<FreshIngredients> noIntersects = [];

        long fresh = 0;
        foreach (var f in freshIngredientsList)
        {
            Update(accumulated, noIntersects, f);
            foreach (var noIntersect in noIntersects)
            {
                fresh += noIntersect.Length;
            }
        }

        Console.WriteLine(fresh);
    }

    private static void Update(List<FreshIngredients> accumulated, List<FreshIngredients> noIntersects, FreshIngredients f)
    {
        noIntersects.Clear();

        foreach (var a in accumulated)
        {

        }
    }

    private record struct FreshIngredients(long Start, long End)
    {
        public long Length = End - Start + 1;

        public static FreshIngredients Parse(string line)
        {
            var span = line.AsSpan();

            long start = -1;
            long end = -1;

            int i = 0;
            foreach (var r in span.Split('-'))
            {
                if (i == 0)
                {
                    start = long.Parse(span[r]);
                }
                else
                {
                    end = long.Parse(span[r]);
                }

                i++;
            }

            if (start == -1 || end == -1)
            {
                throw new Exception("Unassigned start or end!");
            }

            return new FreshIngredients(start, end);
        }
    }
}