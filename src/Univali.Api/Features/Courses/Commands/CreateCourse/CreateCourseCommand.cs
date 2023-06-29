using MediatR;

namespace Univali.Api.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommand : IRequest<CreateCourseDto> {
    public int PublisherId { get; set; }
    public Models.CourseWithAuthorsForCreationDto Dto { get; set; } = new();
}