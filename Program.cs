using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSONParser
{
  class Program
  {
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
      //SetupData();
      ReadUserInput();

      // Perform operations
      Console.WriteLine("*********** Save Data ***********");
      SaveFile();
      Console.WriteLine("*********** Load Data ***********");
      LoadFile();
    }

    static void ReadUserInput() {

      // Read input
      Console.WriteLine("Input student information");

      Console.Write("First Name: ");
      string firstName = Console.ReadLine();

      Console.Write("Last Name: ");
      string lastName = Console.ReadLine();

      Console.Write("Birthday('yyyy-mm-dd'): ");
      string birthdayStr = Console.ReadLine();

      Console.Write("Grades('a-b-c'): ");
      string gradeStr = Console.ReadLine();

      // Set data
      student = new Student();
      student.FirstName = firstName;
      student.LastName = lastName;
      int[] date = ParseString(birthdayStr);
      student.Birthday = new DateTime(date[0],date[1],date[2]);
      student.Grades = ParseString(gradeStr);
    }

    static void SetupData()
    {
      // Data
      student = new Student();
      student.FirstName = "Quang";
      student.LastName = "Nguyen";
      student.Birthday = new DateTime(1992, 02, 03);
      student.Grades = new int[] { 8, 9, 8 };
    }

    static void SaveFile()
    {
      Console.WriteLine($"Start writing to file: {FILE_PATH} .... ");
      fileHandler.SaveDataToFile(student, FILE_PATH);
      Console.WriteLine($"Complete writing.");
    }

    static void LoadFile()
    {
      Console.WriteLine($"Start loading data from file: {FILE_PATH} .... ");
      Student savedStudent = fileHandler.LoadDataFromFile(FILE_PATH);
      Console.WriteLine($"Complete writing.");
      Console.WriteLine($"Data loaded: {savedStudent}");
    }

    // A helper method to parse string to int array
    private static int[] ParseString(string dateStr)
    {
      string[] arr = dateStr.Trim().Split("-");
      int[] items = new int[arr.Length];
      for (int i = 0; i < arr.Length; i++)
      {
        items[i] = int.Parse(arr[i].Trim());
      }
      return items;
    }
  }
}
