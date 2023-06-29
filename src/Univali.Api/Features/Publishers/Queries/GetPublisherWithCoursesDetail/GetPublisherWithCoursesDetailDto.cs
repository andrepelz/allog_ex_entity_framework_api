using Univali.Api.Models;

namespace Univali.Api.Features.Publishers.Queries.GetPublisherWithCoursesDetail;

public class GetPublisherWithCoursesDetailDto {
    public int PublisherId { get; set; }
    public string FirstName { get; set; } = string.Empty;
   	public string LastName { get; set; } = string.Empty;
	public string Cpf { get; set; } = string.Empty;
    public ICollection<CourseDto> Courses { get; set; } = new List<CourseDto>();
}