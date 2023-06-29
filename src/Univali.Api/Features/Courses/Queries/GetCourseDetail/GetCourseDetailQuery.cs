using MediatR;

namespace Univali.Api.Features.Courses.Queries.GetCourseDetail;

public class GetCourseDetailQuery : IRequest<GetCourseDetailDto> {
    public int PublisherId { get; set; }
    public int CourseId { get; set; }
}