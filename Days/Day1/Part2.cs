namespace AdventOfCode2025.Days.Day1;

internal class Part2 : DayPart
{
    //public override bool HasPrecedence => true;
    //public override string InputFile => "Example.txt";
    //public override bool ShouldRejectWhiteSpaceLines => false;

    public override void Run(List<string> input)
    {
        List<Move> moves = [.. input.Select(Move.Parse)];
        Dial dial = new(50);
        int zeros = 0;
        for (int i = 0; i < moves.Count; i++)
        {
            bool right = moves[i].Right;
            for (int j = 0; j < moves[i].Count; j++)
            {
                if (dial.Step(new Move(right, 1)) == 0)
                {
                    zeros++;
                }
            }
        }

        Console.WriteLine(zeros);
    }

    private record struct Move(bool Right, int Count)
    {
        public static Move Parse(string line)
        {
            bool right = line[0] == 'R';
            int count = int.Parse(line.AsSpan(1));
            return new(right, count);
        }
    }

    private class Dial(int position)
    {
        private int position = position;

        public int Step(Move move)
        {
            // rotate right (increase)
            if (move.Right)
            {
                position += move.Count;
            }
            // rotate left (decrease)
            else
            {
                position -= move.Count;
            }

            position %= 100;
            return position;
        }
    }
}