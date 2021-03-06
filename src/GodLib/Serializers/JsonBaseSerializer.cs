using Newtonsoft.Json;

namespace GodLib.Serializers
{
	public class JsonBaseSerializer<T> : IBaseSerializer<T>
	{
		public string Serialize(T obj)
		{
			return JsonConvert.SerializeObject(obj);
		}

		public T Deserialize(string jsonObj)
		{
			return JsonConvert.DeserializeObject<T>(jsonObj);
		}
	}
}