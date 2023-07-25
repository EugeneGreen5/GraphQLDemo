namespace GraphQLDemo.API.Data.DTO;

public class StudentDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double GPA { get; set; } // средний балл
    public IEnumerable<CourseDTO> Courses { get; set; }
}
