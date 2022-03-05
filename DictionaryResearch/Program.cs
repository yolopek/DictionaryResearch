namespace DictionaryResearch;

internal static class Program
{
	internal static void Main()
	{
		// Активность «Исследование Dictionary»
		// 
		var firstArray = new[] { 1, 3, 2, 4, 2, 4 };
		var secondArray = new[] { 1, 6, 7, 8, 9, 4 };

		var hashSet = new HashSet<int>();

		foreach (var i in firstArray)
		{
			hashSet.Add(i);
		}

		foreach (var i in secondArray)
		{
			hashSet.Add(i);
		}

		foreach (var i in Enumerable.Range(10,1000000000))
		{
			hashSet.Add(i * 101);
		}
		
		Console.WriteLine(hashSet.Contains(2));
		Console.WriteLine(hashSet.Contains(5));
	}
}