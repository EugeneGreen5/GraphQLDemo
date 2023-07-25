using GraphQLDemo.API.Data.DTO;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.Data;

public class SchoolDbContext : DbContext
{
    public DbSet<CourseDTO> Courses { get; set; }
    public DbSet<InstructorDTO> Instructors { get; set; }
    public DbSet<StudentDto> Students { get; set; }
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
        if (Database.EnsureCreated())
            Database.Migrate();
    }
}
