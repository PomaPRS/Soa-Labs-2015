using Problem._0.Entities;
using Problem._0.Serializers;

namespace Problem._0.Adapters
{
	public class XmlIOAdapter : FormatAdapter<Input, Output>
	{
		public XmlIOAdapter(IAdapter<Input, Output> adapter) 
			: base(adapter, new XmlBaseSerializer<Input>(), new XmlBaseSerializer<Output>())
		{
		}
	}
}