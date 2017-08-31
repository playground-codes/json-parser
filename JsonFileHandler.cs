using System;
using System.IO;
namespace JSONParser
{
  public class JsonFileHandler : FileHandler
  {
    JsonHandler jsonHandler;
    public JsonFileHandler(JsonHandler jsonHandler)
    {
      this.jsonHandler = jsonHandler;
    }

    public Student LoadDataFromFile(string filePath)
    {
      TextReader reader = null;

      // Read json from file
      try
      {
        reader = new StreamReader(filePath);
        string json = reader.ReadToEnd();
        return jsonHandler.Decode(json);
      }
      finally
      {
        if (reader != null) reader.Close();
      }
    }

    public void SaveDataToFile(Student student, string filePath)
    {
      TextWriter writer = null;

      // Compose json string 
      string json = jsonHandler.Encode(student);

      // Write it to file
      try
      {
        writer = new StreamWriter(filePath);
        writer.WriteLine(json);
      }
      finally
      {
        if (writer != null) writer.Close();
      }
    }
  }
}
