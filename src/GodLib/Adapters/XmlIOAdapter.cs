using GodLib.Entities;
using GodLib.Serializers;

namespace GodLib.Adapters
{
	public class XmlIOAdapter : FormatAdapter<Input, Output>
	{
		public XmlIOAdapter(IAdapter<Input, Output> adapter) 
			: base(adapter, new XmlBaseSerializer<Input>(), new XmlBaseSerializer<Output>())
		{
		}
	}
}