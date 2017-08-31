using System;
namespace JSONParser
{
  public class Student
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public int[] Grades { get; set; }

    public override string ToString()
    {
      return string.Format("[Student: FirstName={0}, LastName={1}, Birthday={2}, Grades={3}]", FirstName, LastName, Birthday, string.Join(",", Grades));
    }
  }
}
