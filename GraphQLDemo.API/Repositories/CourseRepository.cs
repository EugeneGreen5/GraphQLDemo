 using GraphQLDemo.API.Data;
using GraphQLDemo.API.Data.DTO;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly IDbContextFactory<SchoolDbContext> _contextFactory;

    public CourseRepository(IDbContextFactory<SchoolDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<CourseDTO>> GetAll()
    {
        using SchoolDbContext context = _contextFactory.CreateDbContext();
        return await context.Courses.ToListAsync();
    }

    public async Task<CourseDTO> GetById(Guid id)
    {
        using (SchoolDbContext context = _contextFactory.CreateDbContext())
        {
            return await context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        }
    }

    public async Task<CourseDTO> CreateAsync(CourseDTO course)
    {
        using (SchoolDbContext context = _contextFactory.CreateDbContext())
        {
            context.Courses.Add(course);
            await context.SaveChangesAsync();

            return course;
        }
    }

    public async Task<CourseDTO> UpdateAsync(CourseDTO course)
    {
        using (SchoolDbContext context = _contextFactory.CreateDbContext())
        {
            context.Courses.Update(course);
            await context.SaveChangesAsync();

            return course;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using (SchoolDbContext context = _contextFactory.CreateDbContext())
        {
            CourseDTO course = new CourseDTO
            {
                Id = id
            };

            context.Courses.Remove(course);
            return await context.SaveChangesAsync() > 0;

        }
    }
}
