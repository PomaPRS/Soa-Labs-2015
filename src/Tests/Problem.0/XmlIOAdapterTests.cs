using NUnit.Framework;
using Problem._0.Adapters;

namespace Tests.Problem._0
{
	public class XmlIOAdapterTests
	{
		private IOAdapter _ioAdapter;
		private XmlIOAdapter _xmlIOAdapter;

		[SetUp]
		public void SetUp()
		{
			_ioAdapter = new IOAdapter();
			_xmlIOAdapter = new XmlIOAdapter(_ioAdapter);
		}

		[Test]
		public void Convert_Test()
		{
			var xmlInput = "<Input><K>10</K><Sums><decimal>1.01</decimal><decimal>2.02</decimal></Sums><Muls><int>1</int><int>4</int></Muls></Input>";
			var exceptedObj = "<Output><SumResult>30.30</SumResult><MulResult>4</MulResult><SortedInputs><decimal>1</decimal><decimal>1.01</decimal><decimal>2.02</decimal><decimal>4</decimal></SortedInputs></Output>";
			var jsonOutput = _xmlIOAdapter.Convert(xmlInput);
			Assert.AreEqual(exceptedObj, jsonOutput);
		}
	}
}