namespace Problem._0.Adapters
{
	public interface IAdapter<TInput, TOutput>
	{
		TOutput Convert(TInput input);
	}
}