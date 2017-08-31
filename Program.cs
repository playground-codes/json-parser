using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSONParser
{
  class Program
  {
    static string TEST_JSON = "{\"FirstName\":\"Quang\",\"LastName\":\"Nguyen\",\"Birthday\":\"1992-02-03T00:00:00\",\"Grades\":[8,9,8]}";
    static void Main(string[] args)
    {
      testJSON();
    }

    static void testJSON()
    {
      Student student = new Student();
      student.FirstName = "Quang";
      student.LastName = "Nguyen";
      student.Birthday = new DateTime(1992, 02, 03);
      student.Grades = new int[] { 8, 9, 8 };

      Console.WriteLine("JSON serialziation:");
      Console.WriteLine(encodeStudent(student));

      Console.WriteLine("JSON deserialization:");
      Console.WriteLine(decodeStudent(TEST_JSON));
    }

    static string encodeStudent(Student student)
    {
      return JsonConvert.SerializeObject(student);
    }

    static Student decodeStudent(String json)
    {
      Student student = JObject.Parse(json).ToObject<Student>();
      return student;
    }
  }
}
