using AoCHelper;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AoC_2024
{
    internal partial class Day03 : BaseDay
    {
        private readonly string _input;

        public Day03()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1()
        {
            long solution = 0;
            for (var match = Part1Regex().Match(_input); match.Success; match = match.NextMatch())
            {
                var variables = match.ValueSpan[4..^1];
                var commaIdx = variables.IndexOf(',');
                var numA = int.Parse(variables[..(commaIdx)]);
                var numB = int.Parse(variables[(commaIdx + 1)..]);
                solution += numA * numB;
            }
            return new(solution.ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            bool state = true;
            long solution = 0;
            for (var match = Part2Regex().Match(_input); match.Success; match = match.NextMatch())
            {
                var value = match.Value;

                if (value is "do()")
                {
                    state = true;
                    continue;
                }
                if (value is "don't()")
                    state = false;

                if (!state)
                    continue;

                var variables = match.ValueSpan[4..^1];
                var commaIdx = variables.IndexOf(',');

                var numA = int.Parse(variables[..(commaIdx)]);
                var numB = int.Parse(variables[(commaIdx + 1)..]);
                solution += numA * numB;
            }
            return new(solution.ToString());
        }

        [GeneratedRegex("mul\\(\\d{1,3},\\d{1,3}\\)")]
        private static partial Regex Part1Regex();

        [GeneratedRegex("(mul\\(\\d{1,3},\\d{1,3}\\))|(do\\(\\))|(don't\\(\\))")]
        private static partial Regex Part2Regex();
    }
}
