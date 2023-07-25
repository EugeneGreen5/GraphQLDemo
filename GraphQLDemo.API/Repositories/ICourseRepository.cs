using GraphQLDemo.API.Data.DTO;

namespace GraphQLDemo.API.Repositories;

public interface ICourseRepository
{
    public Task<IEnumerable<CourseDTO>> GetAll();
    public Task<CourseDTO> GetById(Guid id);
    public Task<CourseDTO> CreateAsync(CourseDTO course);
    public Task<CourseDTO> UpdateAsync(CourseDTO course);
    public Task<bool> DeleteAsync(Guid id);
}
