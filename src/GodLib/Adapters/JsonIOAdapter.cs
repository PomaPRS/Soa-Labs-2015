using GodLib.Entities;
using GodLib.Serializers;

namespace GodLib.Adapters
{
	public class JsonIOAdapter : FormatAdapter<Input, Output>
	{
		public JsonIOAdapter(IAdapter<Input, Output> adapter) 
			: base(adapter, new JsonBaseSerializer<Input>(), new JsonBaseSerializer<Output>())
		{
		}
	}
}