namespace AdventOfCode2025.Days.Day3;

internal class Part2 : DayPart
{
    //public override bool HasPrecedence => true;
    //public override string InputFile => "Example.txt";
    //public override bool ShouldRejectWhiteSpaceLines => false;

    public override void Run(List<string> input)
    {
        List<Bank> banks = [.. input.Select(Bank.Parse)];
        long sum = 0;
        foreach (var bank in banks)
        {
            sum += bank.GetMaxJoltage();
        }

        Console.WriteLine(sum);
    }

    public record Bank(byte[] Batteries)
    {
        private const int Count = 12;
        private static readonly List<byte> digits = [];

        public static Bank Parse(string line)
        {
            byte[] batteries = new byte[line.Length];
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                byte battery = (byte)(c - '0');
                batteries[i] = battery;
            }
            return new(batteries);
        }

        public long GetMaxJoltage()
        {
            digits.Clear();

            int startIndex = 0;
            int nextStartIndex = 0;
            while (digits.Count < Count)
            {
                byte max = 0;
                int endIndex = Batteries.Length - Count + digits.Count + 1;
                for (int i = startIndex; i < endIndex; i++)
                {
                    byte battery = Batteries[i];
                    if (battery > max)
                    {
                        max = battery;
                        nextStartIndex = i + 1;
                    }
                }

                startIndex = nextStartIndex;
                digits.Add(max);
            }

            long sum = 0;
            long place = 1;
            for (int i = digits.Count - 1; i >= 0; i--)
            {
                sum += digits[i] * place;
                place *= 10;
            }
            return sum;
        }
    }
}