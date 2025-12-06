namespace AdventOfCode2025.Days.Day6;

internal class Part1 : DayPart
{
    //public override bool HasPrecedence => true;
    //public override string InputFile => "Example.txt";
    //public override bool ShouldRejectWhiteSpaceLines => false;

    public override void Run(List<string> input)
    {
        List<List<int>> numbers = [];
        for (int i = 0; i < input.Count - 1; i++)
        {
            string line = input[i];
            var split = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            List<int> n = [];
            foreach (var s in split)
            {
                n.Add(int.Parse(s));
            }
            numbers.Add(n);
        }

        List<bool> isMultiplication = [];
        var lastLine = input.Last();
        foreach (var split in lastLine.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
        {
            isMultiplication.Add(split == "*");
        }

        List<Problem> problems = [];
        for (int i = 0; i < isMultiplication.Count; i++)
        {
            List<int> data = [];
            for (int j = 0; j < numbers.Count; j++)
            {
                data.Add(numbers[j][i]);
            }
            problems.Add(new(data, isMultiplication[i]));
        }

        long sum = 0;
        foreach (var problem in problems)
        {
            sum += problem.Solve();
        }

        Console.WriteLine(sum);
    }

    private record Problem(List<int> Data, bool IsMult)
    {
        public long Solve()
        {
            if (IsMult)
            {
                long product = 1;
                foreach (var d in Data)
                {
                    product *= d;
                }
                return product;
            }
            else
            {
                long sum = 0;
                foreach (var d in Data)
                {
                    sum += d;
                }
                return sum;
            }
        }
    }
}