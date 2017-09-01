using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace JSONParser
{
  public class JsonHandler
  {
    public String Encode(Student student) {
      return JsonConvert.SerializeObject(student);
    }
    public Student Decode(String json) {
      return JObject.Parse(json).ToObject<Student>();
    }
  }
}
