using System;
using Problem._0.Adapters;
using Problem._0.Entities;

namespace Problem._0.Factories
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