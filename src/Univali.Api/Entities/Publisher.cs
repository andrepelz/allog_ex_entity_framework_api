namespace Univali.Api.Entities;

public class Publisher {
    public int PublisherId { get; set; }
    public string FirstName { get; set; } = string.Empty;
   	public string LastName { get; set; } = string.Empty;
	public string Cpf  {get; set; } = string.Empty;
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}