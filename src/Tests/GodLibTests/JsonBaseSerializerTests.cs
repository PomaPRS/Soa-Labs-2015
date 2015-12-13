using GodLib.Entities;
using GodLib.Serializers;
using NUnit.Framework;

namespace Tests.Problem._0
{
	public class JsonBaseSerializerTests
	{
		[Test]
		public void SerializeInput_Test()
		{
			var input = new Input
			{
				K = 10,
				Sums = new[] {1.01m, 2.02m, 2},
				Muls = new[] {1, 4}
			};

			var exceptedObj = "{\"K\":10,\"Sums\":[1.01,2.02,2.0],\"Muls\":[1,4]}";
			var jsonBaseSerializer = new JsonBaseSerializer<Input>();
			var jsonOutput = jsonBaseSerializer.Serialize(input);
			Assert.AreEqual(exceptedObj, jsonOutput);
		}

		[Test]
		public void DeserializeInput_Test()
		{
			var exceptedObj = new Input
			{
				K = 10,
				Sums = new[] { 1.01m, 2.02m, 2 },
				Muls = new[] { 1, 4 }
			};

			var input = "{\"K\":10,\"Sums\":[1.01,2.02,2.0],\"Muls\":[1,4]}";
			var jsonBaseSerializer = new JsonBaseSerializer<Input>();
			var jsonOutput = jsonBaseSerializer.Deserialize(input);
			Assert.AreEqual(exceptedObj, jsonOutput);
		}

		[Test]
		public void SerializeOutput_Test()
		{
			var output = new Output
			{
				SumResult = 30.30m,
				MulResult = 4,
				SortedInputs = new[] {1m, 1.01m, 2.02m, 4m}
			};

			var exceptedObj = "{\"SumResult\":30.30,\"MulResult\":4,\"SortedInputs\":[1.0,1.01,2.02,4.0]}";
			var jsonBaseSerializer = new JsonBaseSerializer<Output>();
			var jsonOutput = jsonBaseSerializer.Serialize(output);
			Assert.AreEqual(exceptedObj, jsonOutput);
		}

		[Test]
		public void DeserializeOutput_Test()
		{
			var exceptedObj = new Output
			{
				SumResult = 30.3m,
				MulResult = 4,
				SortedInputs = new[] { 1m, 1.01m, 2.02m, 4m }
			};

			var output = "{\"SumResult\":30.30,\"MulResult\":4,\"SortedInputs\":[1.0,1.01,2.02,4.0]}";
			var jsonBaseSerializer = new JsonBaseSerializer<Output>();
			var jsonOutput = jsonBaseSerializer.Deserialize(output);
			Assert.AreEqual(exceptedObj, jsonOutput);
		}
	}
}