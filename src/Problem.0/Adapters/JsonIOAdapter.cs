using Newtonsoft.Json;
using Problem._0.Entities;
using Problem._0.Serializers;

namespace Problem._0.Adapters
{
	public class JsonIOAdapter : FormatAdapter<Input, Output>
	{
		public JsonIOAdapter(IAdapter<Input, Output> adapter) 
			: base(adapter, new JsonBaseSerializer<Input>(), new JsonBaseSerializer<Output>())
		{
		}
	}
}