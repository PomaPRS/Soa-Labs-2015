using GodLib.Adapters;
using GodLib.Factories;
using NUnit.Framework;

namespace Tests.Problem._0
{
	public class FormatFactoryTests
	{
		private FormatFactory _formatFactory;

		[SetUp]
		public void SetUp()
		{
			_formatFactory = new FormatFactory();
		}

		[Test]
		public void CreateJsonToXmlSerializer_Test()
		{
			var adapter = _formatFactory.CreateFormatAdapter("json");
			Assert.IsTrue(adapter is JsonIOAdapter);
		}

		[Test]
		public void CreateXmlToJsonSerializer_Test()
		{
			var adapter = _formatFactory.CreateFormatAdapter("xml");
			Assert.IsTrue(adapter is XmlIOAdapter);
		}
	}
}