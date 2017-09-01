using System;
using Xunit;
namespace JSONParser.tests
{
  public class JsonHandlerTest
  {
    const string TEST_JSON = "{\"FirstName\":\"Quang\",\"LastName\":\"Nguyen\",\"Birthday\":\"1992-02-03T00:00:00\",\"Grades\":[8,9,8]}";
    Student student;

    JsonHandler jsonHandler;
    public JsonHandlerTest() {
      // Data
      student = new Student();
      student.FirstName = "Quang";
      student.LastName = "Nguyen";
      student.Birthday = new DateTime(1992, 02, 03);
      student.Grades = new int[] { 8, 9, 8 };

      // Test object
      jsonHandler = new JsonHandler();
    }

    [Fact]
    public void EncodeDataToJson() {
      Assert.Equal(jsonHandler.Encode(student), TEST_JSON);
    }

    [Fact]
    public void DecodeJsonToData() {
      Assert.Equal(jsonHandler.Decode(TEST_JSON), student);
    }
  }
}
