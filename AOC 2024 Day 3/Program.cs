using AOC_2024_Day_3.Properties;
using System.Text.RegularExpressions;

var data = Resources.ResourceManager.GetString("Data")!;

Part1(data);
Part2(data);

static void Part1(string data)
{
    long solution = 0;
    for (var match = Part1Regex().Match(data); match.Success; match = match.NextMatch())
    {
        var variables = match.ValueSpan[4..^1];
        var commaIdx = variables.IndexOf(',');
        var numA = int.Parse(variables[..(commaIdx)]);
        var numB = int.Parse(variables[(commaIdx + 1)..]);
        solution += numA * numB;
    }
    Console.WriteLine(solution);
}

static void Part2(string data)
{
    bool state = true;
    long solution = 0;
    for (var match = Part2Regex().Match(data); match.Success; match = match.NextMatch())
    {
        var value = match.Value;

        if (value is "do()")
        {
            state = true;
            continue;
        }
        if(value is "don't()")
            state = false;

        if (!state)
            continue;

        var variables = match.ValueSpan[4..^1]; 
        var commaIdx = variables.IndexOf(',');

        var numA = int.Parse(variables[..(commaIdx)]);
        var numB = int.Parse(variables[(commaIdx + 1)..]);
        solution += numA * numB;
    }
    Console.WriteLine(solution);
}

partial class Program
{
    [GeneratedRegex("mul\\(\\d{1,3},\\d{1,3}\\)")]
    private static partial Regex Part1Regex();

    [GeneratedRegex("(mul\\(\\d{1,3},\\d{1,3}\\))|(do\\(\\))|(don't\\(\\))")]
    private static partial Regex Part2Regex();
}
