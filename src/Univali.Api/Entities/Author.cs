namespace Univali.Api.Entities;

public class Author {
    public int AuthorId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}