using Bogus;
using GraphQLDemo.API.Data;
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

    public async Task<IEnumerable<CourseType>> GetAllCoursesAsync()
    {
        IEnumerable<CourseDTO> courseDTOs = await _courseRepository.GetAll();

        return courseDTOs.Select(c => new CourseType()
        {
            Id = c.Id,
            Name = c.Name,
            Subject = c.Subject,
            InstructorId = c.InstructorId,
            
        });
    }

    [UseDbContext(typeof(SchoolDbContext))]
    [UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
    public IQueryable<CourseType> GetPaginatedCoursesAsync([ScopedService] SchoolDbContext context)
    {
        return context.Courses.Select(c => new CourseType()
        {
            Id = c.Id,
            Name = c.Name,
            Subject = c.Subject,
            InstructorId = c.InstructorId,

        });
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
