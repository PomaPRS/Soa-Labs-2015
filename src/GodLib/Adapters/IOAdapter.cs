using System.Linq;
using GodLib.Entities;

namespace GodLib.Adapters
{
	public class IOAdapter : IAdapter<Input, Output>
	{
		public Output Convert(Input input)
		{
			var sumResult = input.K*input.Sums.Sum();
			var mulResult = input.Muls.Aggregate(1, (a, b) => a*b);
			var sortedInputs = input.Muls
				.Select(x => (decimal) x)
				.Concat(input.Sums)
				.OrderBy(x => x)
				.ToArray();
			return new Output
			{
				SumResult = sumResult,
				MulResult = mulResult,
				SortedInputs = sortedInputs
			};
		}
	}
}