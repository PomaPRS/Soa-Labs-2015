using GodLib.Adapters;
using NUnit.Framework;

namespace Tests.Problem._0
{
	public class JsonIOAdapterTests
	{
		private IOAdapter _ioAdapter;
		private JsonIOAdapter _jsonIoAdapter;

		[SetUp]
		public void SetUp()
		{
			_ioAdapter = new IOAdapter();
			_jsonIoAdapter = new JsonIOAdapter(_ioAdapter);
		}

		[Test]
		public void Convert_Test()
		{
			var jsonInput = "{\"K\":10,\"Sums\":[1.01,2.02],\"Muls\":[1,4]}";
			var exceptedObj = "{\"SumResult\":30.30,\"MulResult\":4,\"SortedInputs\":[1.0,1.01,2.02,4.0]}";
			var jsonOutput = _jsonIoAdapter.Convert(jsonInput);
			Assert.AreEqual(exceptedObj, jsonOutput);
		}
	}
}