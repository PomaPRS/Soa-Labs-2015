using GodLib.Adapters;
using GodLib.Entities;
using NUnit.Framework;

namespace Tests.Problem._0
{
	public class IOAdapterTests
	{
		private IOAdapter _ioAdapter;

		[SetUp]
		public void SetUp()
		{
			_ioAdapter = new IOAdapter();
		}

		[Test]
		public void ConvertInputToOutput_Test()
		{
			var input = new Input
			{
				K = 10,
				Sums = new[] { 1.01m, 2.02m },
				Muls = new[] { 1, 4 }
			};

			var exceptedOutput = new Output
			{
				SumResult = 30.30m,
				MulResult = 4,
				SortedInputs = new[] { 1m, 1.01m, 2.02m, 4m }
			};

			var output = _ioAdapter.Convert(input);
			Assert.AreEqual(exceptedOutput, output);
		}
	}
}