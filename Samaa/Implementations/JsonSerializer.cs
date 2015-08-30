using Intelife.Configuration;
using Newtonsoft.Json;
using System;

namespace Samaa.Implementations
{
  public class JsonSerializer : IObjectSerializer
  {
    public object Deserialize(string str, Type type)
    {
      if (string.IsNullOrEmpty(str))
        throw new ArgumentNullException("str is null");
      if (type == null)
        throw new ArgumentNullException("type is null");

      return JsonConvert.DeserializeObject(str, type);
    }

    public T Deserialize<T>(string str)
    {
      if (string.IsNullOrEmpty(str))
        throw new ArgumentNullException("str is null");

      return JsonConvert.DeserializeObject<T>(str);
    }

    public string Serialize(object obj)
    {
      if (obj == null)
        throw new ArgumentNullException("object to serialize is null");

      return JsonConvert.SerializeObject(obj);
    }
  }
}
