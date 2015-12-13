namespace GodLib.Adapters
{
	public interface IAdapter<TInput, TOutput>
	{
		TOutput Convert(TInput input);
	}
}