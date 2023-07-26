using GraphQLDemo.API.Data.DTO;
using GraphQLDemo.API.DataLoaders;
using GraphQLDemo.API.Models;
using GraphQLDemo.API.Repositories;

namespace GraphQLDemo.API.Schema.Types;

public class CourseType
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Subject Subject { get; set; }

    public Guid InstructorId { get; set; }
    [GraphQLNonNullType]
    public async Task<InstructorType> Instructor([Service] InstructorDataLoader instructorDataLoader)
    {
        InstructorDTO instructorDTO = await instructorDataLoader.LoadAsync(InstructorId);
        return new InstructorType
        {
            Id = instructorDTO.Id,
            FirstName = instructorDTO.FirstName,
            LastName = instructorDTO.LastName, 
            Salary = instructorDTO.Salary
        };
    }
    public IEnumerable<StudentType> Students { get; set; }
}
