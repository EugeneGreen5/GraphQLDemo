using GraphQLDemo.API.Data.DTO;
using GraphQLDemo.API.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.Repositories;

public class InstructorRepository : IInstructorRepository
{
    private readonly IDbContextFactory<SchoolDbContext> _contextFactory;

    public InstructorRepository(IDbContextFactory<SchoolDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<InstructorDTO>> GetAllAsync()
    {
        using (SchoolDbContext context = _contextFactory.CreateDbContext())
        {
            return await context.Instructors.ToListAsync();
        }
    }

    public async Task<InstructorDTO> GetByIdAsync(Guid instructorId)
    {
        using (SchoolDbContext context = _contextFactory.CreateDbContext())
        {
            return await context.Instructors.FirstOrDefaultAsync(x => x.Id == instructorId);
        }
    }

    public async Task<IEnumerable<InstructorDTO>> GetManyByIdsAsync(IReadOnlyList<Guid> instructorIds)
    {
        using (SchoolDbContext context = _contextFactory.CreateDbContext())
        {
            return await context.Instructors.Where(c => instructorIds.Contains(c.Id)).ToListAsync();
        }
    }
}
