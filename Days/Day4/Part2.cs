namespace AdventOfCode2025.Days.Day4;

internal class Part2 : DayPart
{
    //public override bool HasPrecedence => true;
    //public override string InputFile => "Example.txt";
    //public override bool ShouldRejectWhiteSpaceLines => false;

    public override void Run(List<string> input)
    {
        List<(int, int)> toRemove = [(-1, -1)];

        int removedCount = 0;

        while (toRemove.Count != 0)
        {
            toRemove.Clear();
            for (int y = 0; y < input.Count; y++)
            {
                for (int x = 0; x < input[0].Length; x++)
                {
                    if (Get(input, x, y) == Tile.Paper)
                    {
                        if (GetAdjacentCount(input, x, y) < 4)
                        {
                            toRemove.Add((x, y));

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

            for (int i = 0; i < toRemove.Count; i++)
            {
                (int x, int y) = toRemove[i];
                var chars = input[y].ToCharArray();
                chars[x] = '.';
                input[y] = new(chars);

                removedCount++;
            }
        }

        Console.WriteLine(removedCount);
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