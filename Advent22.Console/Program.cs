var days = AppDomain.CurrentDomain.GetAssemblies()
    .SelectMany(assembly => assembly.GetTypes())
    .Where(t => !t.IsAbstract && typeof(Day).IsAssignableFrom(t))
    .Select(Activator.CreateInstance)
    .Cast<Day>()
    .OrderBy(d => d.DayNumber);

foreach (var day in days)
{
    Console.WriteLine($"Day {day.DayNumber} Task 1 Answer: {day.Part1Solution()}");
    Console.WriteLine($"Day {day.DayNumber} Task 2 Answer: {day.Part2Solution()}");
    Console.WriteLine();
}