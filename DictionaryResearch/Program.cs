using System.Diagnostics;

namespace DictionaryResearch;

internal static class Program
{
	internal const int DictionaryLength = 500000;

	internal static void Main()
	{
		Helper.CheckBuckets(); // для 500к: 672827

		var defaultFilling = new Action(() =>
		{
			var count = Enumerable.Range(0, DictionaryLength).ToDictionary(i => i, i => "Value").Count;
		});
		
		var slowlyFilling = new Action(() =>
		{
			var count = Enumerable.Range(0, DictionaryLength).ToDictionary(i => i * 672827, i => "Value").Count;
		});

		Console.WriteLine(Helper.MeasureTime(defaultFilling));
		Console.WriteLine(Helper.MeasureTime(slowlyFilling));

		// 22 1313
	}
}

internal static class Helper
{
	internal static void CheckBuckets()
	{
		var dictionary = Enumerable.Range(0, Program.DictionaryLength).ToDictionary(i => i, i => "Value");
		var count = dictionary.Count;
		Console.WriteLine(); // debug button
	}

	internal static long MeasureTime(Action action)
	{
		var time = new Stopwatch();
		GC.Collect();
		GC.WaitForPendingFinalizers();
		time.Restart();
		action.Invoke();
		time.Stop();
		return time.ElapsedMilliseconds;
	}
}