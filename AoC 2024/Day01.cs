using AoCHelper;

namespace AoC_2024
{
    internal class Day01 : BaseDay
    {
        private readonly string _input;

        private readonly int[] listLeft;
        private readonly int[] listRight;

        public Day01()
        {
            _input = File.ReadAllText(InputFilePath);

            var locations = _input!.Split(Environment.NewLine).SelectMany((x) => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)).Select(int.Parse);
            listLeft = locations.Where((item, idx) => (idx % 2) == 0).ToArray();
            listRight = locations.Where((item, idx) => (idx % 2) == 1).ToArray();

            Array.Sort(listLeft);
            Array.Sort(listRight);
        }

        public override ValueTask<string> Solve_1()
        {
            var zippedList = listLeft.Zip(listRight);
            var solution = zippedList.Sum((a) => Math.Abs(a.First - a.Second));

            return new(solution.ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            var solution = listLeft.Select((x) => x * listRight.Count((y) => x == y)).Sum();

            return new(solution.ToString());
        }
    }
}
