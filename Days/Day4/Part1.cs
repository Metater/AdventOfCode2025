namespace AdventOfCode2025.Days.Day4;

internal class Part1 : DayPart
{
    //public override bool HasPrecedence => true;
    //public override string InputFile => "Example.txt";
    //public override bool ShouldRejectWhiteSpaceLines => false;

    public override void Run(List<string> input)
    {
        int accessibleCount = 0;

        for (int y = 0; y < input.Count; y++)
        {
            for (int x = 0; x < input[0].Length; x++)
            {
                if (Get(input, x, y) == Tile.Paper)
                {
                    if (GetAdjacentCount(input, x, y) < 4)
                    {
                        accessibleCount++;

                        //Console.Write('x');
                    }
                    else
                    {
                        //Console.Write('@');
                    }
                }
                else
                {
                    //Console.Write('.');
                }
            }

            //Console.WriteLine();
        }

        Console.WriteLine(accessibleCount);
    }

    private static int GetAdjacentCount(List<string> input, int x, int y)
    {
        int count = 0;
        if (Get(input, x + 1, y) == Tile.Paper)
        {
            count++;
        }
        if (Get(input, x - 1, y) == Tile.Paper)
        {
            count++;
        }
        if (Get(input, x, y + 1) == Tile.Paper)
        {
            count++;
        }
        if (Get(input, x, y - 1) == Tile.Paper)
        {
            count++;
        }
        if (Get(input, x + 1, y - 1) == Tile.Paper)
        {
            count++;
        }
        if (Get(input, x - 1, y + 1) == Tile.Paper)
        {
            count++;
        }
        if (Get(input, x + 1, y + 1) == Tile.Paper)
        {
            count++;
        }
        if (Get(input, x - 1, y - 1) == Tile.Paper)
        {
            count++;
        }

        return count;
    }

    private static Tile Get(List<string> input, int x, int y)
    {
        if (y < 0 || y >= input.Count) return Tile.Null;

        string row = input[y];
        if (x < 0 || x >= row.Length) return Tile.Null;

        if (row[x] == '@')
        {
            return Tile.Paper;
        }
        else
        {
            return Tile.Empty;
        }
    }

    private enum Tile
    {
        Null,
        Empty,
        Paper
    }
}