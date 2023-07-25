namespace GraphQLDemo.API.Schema.Types;

public class StudentType
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double GPA { get; set; } // средний балл
}
