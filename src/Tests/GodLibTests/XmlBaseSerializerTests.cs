using GodLib.Entities;
using GodLib.Serializers;
using NUnit.Framework;

namespace Tests.Problem._0
{
	public class XmlBaseSerializerTests
	{
		[Test]
		public void SerializeInput_Test()
		{
			var input = new Input
			{
				K = 10,
				Sums = new[] { 1.01m, 2.02m },
				Muls = new[] { 1, 4 }
			};

			var exceptedObj = "<Input><K>10</K><Sums><decimal>1.01</decimal><decimal>2.02</decimal></Sums><Muls><int>1</int><int>4</int></Muls></Input>";
			var xmlSerializer = new XmlBaseSerializer<Input>();
			var xmlObj = xmlSerializer.Serialize(input);
			Assert.AreEqual(exceptedObj, xmlObj);
		}

		[Test]
		public void DeserializeInput_Test()
		{
			var exceptedObj = new Input
			{
				K = 10,
				Sums = new[] { 1.01m, 2.02m },
				Muls = new[] { 1, 4 }
			};

			var input = "<Input><K>10</K><Sums><decimal>1.01</decimal><decimal>2.02</decimal></Sums><Muls><int>1</int><int>4</int></Muls></Input>";
			var xmlSerializer = new XmlBaseSerializer<Input>();
			var xmlObj = xmlSerializer.Deserialize(input);
			Assert.AreEqual(exceptedObj, xmlObj);
		}

		[Test]
		public void SerializeOutput_Test()
		{
			var output = new Output
			{
				SumResult = 30.30m,
				MulResult = 4,
				SortedInputs = new[] { 1m, 1.01m, 2.02m, 4m }
			};

			var exceptedObj = "<Output><SumResult>30.30</SumResult><MulResult>4</MulResult><SortedInputs><decimal>1</decimal><decimal>1.01</decimal><decimal>2.02</decimal><decimal>4</decimal></SortedInputs></Output>";
			var xmlSerializer = new XmlBaseSerializer<Output>();
			var xmlObj = xmlSerializer.Serialize(output);
			Assert.AreEqual(exceptedObj, xmlObj);
		}

		[Test]
		public void DeserializeOutput_Test()
		{
			var exceptedObj = new Output
			{
				SumResult = 30.30m,
				MulResult = 4,
				SortedInputs = new[] { 1m, 1.01m, 2.02m, 4m }
			};

			var output = "<Output><SumResult>30.30</SumResult><MulResult>4</MulResult><SortedInputs><decimal>1</decimal><decimal>1.01</decimal><decimal>2.02</decimal><decimal>4</decimal></SortedInputs></Output>";
			var xmlSerializer = new XmlBaseSerializer<Output>();
			var xmlObj = xmlSerializer.Deserialize(output);
			Assert.AreEqual(exceptedObj, xmlObj);
		}
	}
}