using GraphQLDemo.API.Data.DTO;

namespace GraphQLDemo.API.Repositories;

public interface IInstructorRepository
{
    public Task<IEnumerable<InstructorDTO>> GetAllAsync();
    public Task<InstructorDTO> GetByIdAsync(Guid id);
    public Task<IEnumerable<InstructorDTO>> GetManyByIdsAsync(IReadOnlyList<Guid> instructorIds);
}
