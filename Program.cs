using System;
using Newtonsoft.Json;

namespace JSONParser
{
  class Program
  {
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

      Console.WriteLine("JSON serialziation");
      Console.WriteLine(encodeStudent(student));
    }

    static string encodeStudent(Student student) {
      return JsonConvert.SerializeObject(student);
    }

    static Student decodeStudent(String json){
      Student student = new Student();
      return student;
    }
  }
}
