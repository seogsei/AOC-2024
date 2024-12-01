using AOC_2024_Day_1.Properties;

var data = Resources.ResourceManager.GetString("Data");

var locations = data!.Split(Environment.NewLine).SelectMany((x) => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)).Select(int.Parse);

var listLeft = locations.Where((item, idx) => (idx % 2) == 0).ToArray();
var listRight = locations.Where((item, idx) => (idx % 2) == 1).ToArray();

Part1(listLeft, listRight);
Part2(listLeft, listRight);

static void Part1(int[] listLeft, int[] listRight)
{
    Array.Sort(listLeft);
    Array.Sort(listRight);

    var zippedList = listLeft.Zip(listRight);
    var totalDistance = zippedList.Sum((a) => Math.Abs(a.First - a.Second));
    Console.WriteLine(totalDistance);
}
static void Part2(int[] listLeft, int[] listRight)
{
    var similarityScore = listLeft.Select((x) => x * listRight.Count((y) => x == y)).Sum();
    Console.WriteLine(similarityScore);
}