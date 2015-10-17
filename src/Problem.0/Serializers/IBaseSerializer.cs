namespace Problem._0.Serializers
{
	public interface IBaseSerializer<T>
	{
		string Serialize(T obj);
		T Deserialize(string formatObj);
	}
}