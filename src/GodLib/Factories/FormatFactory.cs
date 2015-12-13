using System;
using GodLib.Adapters;
using GodLib.Entities;

namespace GodLib.Factories
{
	public class FormatFactory
	{
		public FormatAdapter<Input, Output> CreateFormatAdapter(string format)
		{
			var converter = new IOAdapter();
			switch (format.ToLower())
			{
				case "json":
					return new JsonIOAdapter(converter);
				case "xml":
					return new XmlIOAdapter(converter);
				default:
					throw new ArgumentException();
			}
		}
	}
}