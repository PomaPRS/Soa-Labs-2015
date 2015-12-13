using System.Linq;

namespace GodLib.Entities
{
	public class Output
	{
		public decimal SumResult { get; set; }
		public int MulResult { get; set; }
		public decimal[] SortedInputs { get; set; }

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
			var output = obj as Output;
			if (output == null)
				return false;
			return
				SumResult == output.SumResult &&
				MulResult == output.MulResult &&
				SortedInputs.SequenceEqual(output.SortedInputs);
		}
	}
}