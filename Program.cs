using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSONParser
{
  class Program
  {
    static string TEST_JSON = "{\"FirstName\":\"Quang\",\"LastName\":\"Nguyen\",\"Birthday\":\"1992-02-03T00:00:00\",\"Grades\":[8,9,8]}";
    static string FILE_PATH = "./test.json";
    static Student student;

    static JsonHandler jsonHandler;
    static FileHandler fileHandler;

    static void Main(string[] args)
    {
      // Init handlers
      jsonHandler = new JsonHandler();
      fileHandler = new JsonFileHandler(jsonHandler);

      // Prepare data
      SetupTestData();

      // Tests
      Console.WriteLine("**********************");
      TestJSONHandler();
      Console.WriteLine("**********************");
      TestSaveFile();
      Console.WriteLine("**********************");
      TestLoadFile();
    }

    static void SetupTestData()
    {
      // Data
      student = new Student();
      student.FirstName = "Quang";
      student.LastName = "Nguyen";
      student.Birthday = new DateTime(1992, 02, 03);
      student.Grades = new int[] { 8, 9, 8 };
    }

    static void TestJSONHandler()
    {
      Console.WriteLine("JSON serialziation:");
      Console.WriteLine(jsonHandler.Encode(student));

      Console.WriteLine("JSON deserialization:");
      Console.WriteLine(jsonHandler.Decode(TEST_JSON));
    }

    static void TestSaveFile()
    {
      Console.WriteLine($"Start writing data to file at{FILE_PATH} .... ");
      fileHandler.SaveDataToFile(student, FILE_PATH);
      Console.WriteLine($"Complete writing data to file at{FILE_PATH}.");
    }

    static void TestLoadFile()
    {
      Console.WriteLine($"Start loading data from file at{FILE_PATH} .... ");
      Student savedStudent = fileHandler.LoadDataFromFile(FILE_PATH);
      Console.WriteLine($"Complete writing data to file at{FILE_PATH}.");
      Console.WriteLine($"Data loaded: {savedStudent}");
    }
  }
}
