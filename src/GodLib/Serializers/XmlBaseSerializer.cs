using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace GodLib.Serializers
{
	public class XmlBaseSerializer<T> : IBaseSerializer<T>
	{
		private readonly XmlSerializer _xmlSerializer;
		private readonly XmlWriterSettings _xmlWriterSettings;
		private readonly XmlSerializerNamespaces _xmlSerializerNamespaces;

		public XmlBaseSerializer()
		{
			_xmlSerializer = new XmlSerializer(typeof(T));
			_xmlWriterSettings = new XmlWriterSettings
			{
				Indent = false,
				OmitXmlDeclaration = true
			};
			_xmlSerializerNamespaces = new XmlSerializerNamespaces();
			_xmlSerializerNamespaces.Add("", "");
		}

		public string Serialize(T obj)
		{
			using (var stringWriter = new StringWriter())
			{
				using (var xmlWriter = XmlWriter.Create(stringWriter, _xmlWriterSettings))
				{
					_xmlSerializer.Serialize(xmlWriter, obj, _xmlSerializerNamespaces);
					return stringWriter.ToString();
				}
			}
		}

		public T Deserialize(string jsonObj)
		{
			using (var stringReader = new StringReader(jsonObj))
			{
				return (T) _xmlSerializer.Deserialize(stringReader);
			}
		}
	}
}