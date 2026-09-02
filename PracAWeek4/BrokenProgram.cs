using System.Globalization;
namespace Topic4a;
internal static class BrokenProgram
{
static void Main(string[] args)
{
const string input = """
23
+
77
+
3
+
457
*
2
""";
int total = 0;
List<int> items = [];
List<string> symbols = [];
for (int i = 0; i < input.Split("\n").Length; i += 2)
{
items.Add(int.Parse(input.Split('\n')[i].Trim(),CultureInfo.InvariantCulture));
if (i != 0)
{
symbols.Add(input.Split("\n")[i - 1].Trim());
}
}
foreach (var (i, value) in items.Index())
{
if (i == 0) { total = value; }
else if (symbols[i - 1] == "*")
{
total *= value;
}
else
{
total += value;
}
}
Console.WriteLine("Total was: " + total);
Console.WriteLine("Expected total was: 1120");
Console.WriteLine(total == 1120 ? "Your answer was RIGHT!" : "Your answer was WRONG!\nGo and fix it.");
}
}