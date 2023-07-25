using GraphQLDemo.API.Data.DTO;
using GraphQLDemo.API.Repositories;
using GraphQLDemo.API.Schema.Subscriptions;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.API.Schema.Mutations;

public class Mutation
{
    private readonly ICourseRepository _coursesRepository;

    public Mutation(ICourseRepository courses)
    {
        _coursesRepository = courses;
    }

    public async Task<CourseResult> CreateCourse(CourseInput courseInput, [Service] ITopicEventSender topicEventSender) 
    {
        CourseDTO course = new CourseDTO
        {
            Name = courseInput.Name,
            Subject = courseInput.Subject,
            InstructorId = courseInput.InstructorId
        };
        course = await _coursesRepository.CreateAsync(course);

        CourseResult courseType = new CourseResult()
        {
            Id = course.Id,
            Name = course.Name,
            Subject = course.Subject,
            InstructorId = course.InstructorId
        };

        await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), courseType);

        return courseType;
    }

    public async Task<CourseResult> UpdateCourse(Guid id, CourseInput courseInput, [Service] ITopicEventSender topicEventSender)
    {
        CourseDTO course = new CourseDTO
        {
            Id = id,
            Name = courseInput.Name,
            Subject = courseInput.Subject,
            InstructorId = courseInput.InstructorId
        };

        course = await _coursesRepository.UpdateAsync(course);

        CourseResult courseType = new CourseResult()
        {
            Id = course.Id,
            Name = course.Name,
            Subject = course.Subject,
            InstructorId = course.InstructorId
        };

        var updateCourseTopic = $"{course.Id}_{nameof(Subscription.CourseUpdated)}";
        await topicEventSender.SendAsync(updateCourseTopic, course);

        return courseType;
    }

    public async Task<bool> DeleteCourse(Guid id)
    {
        try
        {
            return await _coursesRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
