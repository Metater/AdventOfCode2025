namespace AdventOfCode2025.Days.Day3;

internal class Part1 : DayPart
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
            byte maxFirst = 0;
            int maxFirstIndex = 0;
            for (int i = 0; i < Batteries.Length - 1; i++)
            {
                byte battery = Batteries[i];
                if (battery > maxFirst)
                {
                    maxFirst = battery;
                    maxFirstIndex = i;
                }
            }

            byte maxSecond = 0;
            //int maxSecondIndex = 0;
            for (int i = maxFirstIndex + 1; i < Batteries.Length; i++)
            {
                byte battery = Batteries[i];
                if (battery > maxSecond)
                {
                    maxSecond = battery;
                    //maxSecondIndex = i;
                }
            }

            return maxFirst * 10 + maxSecond;
        }
    }
}