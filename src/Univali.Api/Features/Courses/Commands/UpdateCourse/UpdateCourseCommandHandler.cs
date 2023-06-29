using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, UpdateCourseDto>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public UpdateCourseCommandHandler(IPublisherRepository repository, IMapper mapper) 
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UpdateCourseDto> Handle(UpdateCourseCommand request, CancellationToken cancellationToken) 
    {
        bool success = false;

        var courseFromDatabase = await _repository.GetCourseByIdAsync(request.PublisherId,request.Dto.CourseId);

        if(courseFromDatabase != null) {
            _repository.UpdateCourse(courseFromDatabase, request.Dto);
            await _repository.SaveChangesAsync();

            success = true;
        }

        return new UpdateCourseDto { Success = success };
    }
}