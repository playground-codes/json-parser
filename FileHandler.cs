using System;
using System.IO;
namespace JSONParser
{
  public interface FileHandler
  {
    // Saves student information to a file at the defined file path.
    void SaveDataToFile(Student student, String filePath);

    // Load student information from a file at the defined file path.
    Student LoadDataFromFile(String filePath);
  }
}
