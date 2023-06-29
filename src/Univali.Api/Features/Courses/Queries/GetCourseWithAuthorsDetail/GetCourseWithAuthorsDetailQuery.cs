using MediatR;

namespace Univali.Api.Features.Courses.Queries.GetCourseWithAuthorsDetail;

public class GetCourseWithAuthorsDetailQuery : IRequest<GetCourseWithAuthorsDetailDto> {
    public int PublisherId { get; set; }
    public int CourseId { get; set; }
}