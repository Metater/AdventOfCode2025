namespace AdventOfCode2025.Days.Day6;

internal class Part2 : DayPart
{
    //public override bool HasPrecedence => true;
    //public override string InputFile => "Example.txt";
    //public override bool ShouldRejectWhiteSpaceLines => false;

    public override void Run(List<string> input)
    {
        var problems = new List<Problem>();

        List<char> digits = [];
        char op = ' ';
        List<int> numbers = [];

        for (int x = input[0].Length - 1; x >= 0; x--)
        {
            digits.Clear();

            for (int y = 0; y < input.Count - 1; y++)
            {
                char digit = input[y][x];
                if (char.IsDigit(digit))
                {
                    digits.Add(digit);
                }
            }

            char c = input[^1][x];
            if (c != ' ')
            {
                op = c;
            }

            if (digits.Count > 0)
            {
                numbers.Add(int.Parse(string.Concat(digits)));
            }
            else
            {
                problems.Add(new Problem([.. numbers], op == '*'));
                op = ' ';
                numbers.Clear();
            }
        }

        problems.Add(new Problem([.. numbers], op == '*'));


        long sum = 0;
        foreach (var problem in problems)
        {
            //Console.WriteLine(problem);
            long solution = problem.Solve();
            //Console.WriteLine(solution);
            sum += solution;
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

        public override string ToString()
        {
            return $"{string.Join(", ", Data)} {(IsMult ? "*" : @"+")}";
        }
    }
}