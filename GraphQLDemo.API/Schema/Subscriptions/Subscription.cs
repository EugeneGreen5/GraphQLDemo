using GraphQLDemo.API.Schema.Mutations;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.API.Schema.Subscriptions;

public class Subscription
{
    [Subscribe]
    public CourseResult CourseCreated([EventMessage] CourseResult course) => course;
    [SubscribeAndResolve]
    public ValueTask<ISourceStream<CourseResult>> CourseUpdated(Guid courseId, [Service] ITopicEventReceiver topicEventReceiver)
    {
        var topicName = $"{courseId}_{nameof(CourseUpdated)}";

        return topicEventReceiver.SubscribeAsync<CourseResult>(topicName); ;
    }
}
