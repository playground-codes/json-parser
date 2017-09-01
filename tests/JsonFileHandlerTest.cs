using System;
using Xunit;
using System.IO;
namespace JSONParser.tests
{
  public class JsonFileHandlerTest
  {
    const string JSON = "{\"FirstName\":\"Quang\",\"LastName\":\"Nguyen\",\"Birthday\":\"1992-02-03T00:00:00\",\"Grades\":[8,9,8]}";
    const string MOCK_FILE_PATH = "../../../mock/MOCK_FILE.json";
    const string SAVE_FILE_PATH = "../../../tests/user_saving.json";

    Student student;

    FileHandler fileHandler;
    public JsonFileHandlerTest()
    {
      // Data
      student = new Student();
      student.FirstName = "Quang";
      student.LastName = "Nguyen";
      student.Birthday = new DateTime(1992, 02, 03);
      student.Grades = new int[] { 8, 9, 8 };

      // Test Object
      fileHandler = new JsonFileHandler(new JsonHandler());
    }

    [Fact]
    public void LoadDataFromFile()
    {
      Assert.Equal(fileHandler.LoadDataFromFile(MOCK_FILE_PATH), student);
    }

    [Fact]
    public void SaveDataToFile_TheFileShouldBeCreated()
    {
      // Firstly, delete if it is already exists
      if (File.Exists(SAVE_FILE_PATH))
        File.Delete(SAVE_FILE_PATH);

      // Save data to a new file
      fileHandler.SaveDataToFile(student, SAVE_FILE_PATH);

      // Check whether the expected file is created succefully or not
      Assert.True(File.Exists(SAVE_FILE_PATH));
    }

    [Fact]
    public void SaveDataToFile_TheContentShouldBeCorrect() {
      // Firstly, delete if it is already exists
      if (File.Exists(SAVE_FILE_PATH))
        File.Delete(SAVE_FILE_PATH);

      // Save data to a new file
      fileHandler.SaveDataToFile(student, SAVE_FILE_PATH);

      // Read content and check whether it matches with expected json string or not.
      Assert.Equal(ReadFile(SAVE_FILE_PATH), JSON);
    }

    internal string ReadFile(string filePath)
    {
      TextReader reader = null;

      // Read json from file
      try
      {
        reader = new StreamReader(filePath);
        return reader.ReadToEnd().Trim();

      }
      finally
      {
        if (reader != null) reader.Close();
      }
    }
  }
}
