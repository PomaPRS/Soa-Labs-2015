using Problem._0.Serializers;

namespace Problem._0.Adapters
{
	public abstract class FormatAdapter<TInput, TOutput> : IFormatAdapter
	{
		protected readonly IBaseSerializer<TInput> InputSerializer;
		protected readonly IBaseSerializer<TOutput> OutputSerializer;
		protected readonly IAdapter<TInput, TOutput> Adapter;

		protected FormatAdapter(
			IAdapter<TInput, TOutput> adapter, 
			IBaseSerializer<TInput> inputSerializer, 
			IBaseSerializer<TOutput> outputSerializer)
		{
			Adapter = adapter;
			InputSerializer = inputSerializer;
			OutputSerializer = outputSerializer;
		}

		public string Convert(string formatInput)
		{
			var input = InputSerializer.Deserialize(formatInput);
			var output = Adapter.Convert(input);
			return OutputSerializer.Serialize(output);
		}
	}
}