using Bogus;
using GraphQLDemo.API.Data.DTO;
using GraphQLDemo.API.Models;
using GraphQLDemo.API.Repositories;
using GraphQLDemo.API.Schema.Types;

namespace GraphQLDemo.API.Schema.Queries;

public class Query
{
    private readonly ICourseRepository _courseRepository;

    public Query(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
    {
        return await _courseRepository.GetAll();
    }

    public async Task<CourseDTO> GetCourseById(Guid id)
    {
        CourseDTO course = await _courseRepository.GetById(id);

        course.Id = id;
        return course;
    }

    [GraphQLDeprecated("This is example")]
    public string Instruction => "Example";
}
