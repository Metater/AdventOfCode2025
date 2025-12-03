using System.Text;

namespace AdventOfCode2025.Days.Day2;

internal class Part1 : DayPart
{
    //public override bool HasPrecedence => true;
    //public override string InputFile => "Example.txt";
    //public override bool ShouldRejectWhiteSpaceLines => false;

    public override void Run(List<string> input)
    {
        if (input.Count < 1) return;

        var span = input[0].AsSpan();
        var ranges = span.Split(',');
        List<IdRange> idRanges = [];
        int longestPattern = 0;
        foreach (var range in ranges)
        {
            var chars = span[range];
            idRanges.Add(IdRange.Parse(chars));
            int pattern = (chars.Length / 4) + 1;
            if (longestPattern < pattern)
            {
                longestPattern = pattern;
            }
        }

        long sum = 0;
        foreach (var idRange in idRanges)
        {
            sum += idRange.GetInvalidSum(longestPattern);
        }

        Console.WriteLine(sum);
    }

    private record struct IdRange(long Start, long End)
    {
        private static readonly StringBuilder sb = new();

        public static IdRange Parse(ReadOnlySpan<char> chars)
        {
            long start = 0;
            long end = 0;

            int i = 0;
            foreach (var number in chars.Split('-'))
            {
                if (i == 0)
                {
                    start = long.Parse(chars[number]);
                }
                else
                {
                    end = long.Parse(chars[number]);
                }

                i++;
            }

            return new(start, end);
        }

        public long GetInvalidSum(int longestPattern)
        {
            long sum = 0;
            for (long id = Start; id <= End; id++)
            {
                if (IsInvalidId(id, longestPattern))
                {
                    sum += id;
                }
            }

            return sum;
        }

        private static bool IsInvalidId(long id, int longestPattern)
        {
            sb.Clear();
            sb.Append(id);
            ReadOnlyMemory<char> chars = ReadOnlyMemory<char>.Empty;
            foreach (var chunk in sb.GetChunks())
            {
                chars = chunk;
                break;
            }

            if (chars.Length == 0)
            {
                return false;
            }

            longestPattern = 2;

            for (int i = 2; i <= longestPattern; i++)
            {
                if (chars.Length % i != 0)
                {
                    continue;
                }

                int length = chars.Length / i;

                ReadOnlyMemory<char> pattern = chars[..length];

                bool noMatch = false;
                for (int j = 0; j < chars.Length; j += length)
                {
                    var chunk = chars.Slice(j, length);
                    if (!pattern.Span.SequenceEqual(chunk.Span))
                    {
                        noMatch = true;
                        break;
                    }
                }

                if (!noMatch)
                {
                    //Console.WriteLine(pattern + " " + id);
                    return true;
                }
            }

            return false;
        }
    }
}