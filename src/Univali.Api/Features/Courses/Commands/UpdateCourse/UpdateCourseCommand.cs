using MediatR;

namespace Univali.Api.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseCommand : IRequest<UpdateCourseDto> {
    public int PublisherId { get; set; }
    public Models.CourseForUpdateDto Dto { get; set; } = new();
}