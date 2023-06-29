using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Courses.Queries.GetCourseDetail;

public class GetCourseDetailQueryHandler : IRequestHandler<GetCourseDetailQuery, GetCourseDetailDto>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public GetCourseDetailQueryHandler(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetCourseDetailDto> Handle(GetCourseDetailQuery request, CancellationToken cancellationToken)
    {
        var courseFromDatabase = await _repository.GetCourseByIdAsync(request.PublisherId, request.CourseId);
        return _mapper.Map<GetCourseDetailDto>(courseFromDatabase);
    }
}