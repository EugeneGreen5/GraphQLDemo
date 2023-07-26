using GraphQLDemo.API.Data.DTO;
using GraphQLDemo.API.Repositories;

namespace GraphQLDemo.API.DataLoaders;

public class InstructorDataLoader : BatchDataLoader<Guid, InstructorDTO>
{
    private readonly IInstructorRepository _instructorRepository;

    public InstructorDataLoader(
        IBatchScheduler batchScheduler,
        IInstructorRepository instructorRepository,
        DataLoaderOptions? options = null) 
        : base(batchScheduler, options)
    {
        _instructorRepository = instructorRepository;
    }

    protected override async Task<IReadOnlyDictionary<Guid, InstructorDTO>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
    {
        IEnumerable<InstructorDTO> instructorDTOs = await _instructorRepository.GetManyByIdsAsync(keys);

        return instructorDTOs.ToDictionary(i => i.Id); 
    }
}
