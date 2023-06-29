using MediatR;

namespace Univali.Api.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseCommand : IRequest<DeleteCourseDto> {
    public int PublisherId { get; set; }
    public int CourseId { get; set; }
}