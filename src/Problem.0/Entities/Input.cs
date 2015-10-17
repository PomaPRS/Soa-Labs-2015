using System.Linq;

namespace Problem._0.Entities
{
	public class Input
	{
		public int K { get; set; }
		public decimal[] Sums { get; set; }
		public int[] Muls { get; set; }

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
			var input = obj as Input;
			if (input == null)
				return false;

			return
				K == input.K &&
				Sums.SequenceEqual(input.Sums) &&
				Muls.SequenceEqual(input.Muls);
		}
	}
}