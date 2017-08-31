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
      return string.Format("[Student: FirstName={0}, LastName={1}, Birthday={2}, Grades={3}]",
                           FirstName,
                           LastName,
                           Birthday,
                           string.Join(",", Grades));
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Student)) {
        return false;
      } else {
        Student student = (Student)obj;
        return this.ToString().Equals(student.ToString());
      }
    }
  }
}
