using GraphQLDemo.API.Models;

namespace GraphQLDemo.API.Data.DTO;

public class CourseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Subject Subject { get; set; }
    public Guid InstructorId { get; set; }
    public InstructorDTO Instructor { get; set; }
    public IEnumerable<StudentDto> Students { get; set; }
}
