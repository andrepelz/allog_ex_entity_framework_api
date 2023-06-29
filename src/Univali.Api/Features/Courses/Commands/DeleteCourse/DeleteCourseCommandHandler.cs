using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, DeleteCourseDto> {
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public DeleteCourseCommandHandler(IPublisherRepository repository, IMapper mapper) 
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<DeleteCourseDto> Handle(DeleteCourseCommand request, CancellationToken cancellationToken) 
    {
        bool success = false;

        var courseFromDatabase = await _repository.GetCourseByIdAsync(request.PublisherId, request.CourseId);

        if(courseFromDatabase != null) {
            _repository.RemoveCourse(courseFromDatabase);
            await _repository.SaveChangesAsync();

            success = true;
        }

        return new DeleteCourseDto { Success = success };
    }
}
