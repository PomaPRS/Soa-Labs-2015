using System;
using GodLib.Factories;

namespace Problem._0
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var format = Console.ReadLine();
			var input = Console.ReadLine();

			var formatFactory = new FormatFactory();
			var formatConverter = formatFactory.CreateFormatAdapter(format);
			var output = formatConverter.Convert(input);

			Console.WriteLine(output);
		}
	}
}