using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace JSONParser
{
  public class JsonHandler
  {
    String Encode(Student student) {
      return JsonConvert.SerializeObject(student);
    }
    Student Decode(String json) {
      return JObject.Parse(json).ToObject<Student>();
    }
  }
}
