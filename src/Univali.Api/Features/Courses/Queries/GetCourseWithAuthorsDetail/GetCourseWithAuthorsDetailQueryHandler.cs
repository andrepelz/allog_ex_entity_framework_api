using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Courses.Queries.GetCourseWithAuthorsDetail;

public class GetCourseWithAuthorsDetailQueryHandler : IRequestHandler<GetCourseWithAuthorsDetailQuery, GetCourseWithAuthorsDetailDto>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public GetCourseWithAuthorsDetailQueryHandler(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetCourseWithAuthorsDetailDto> Handle(GetCourseWithAuthorsDetailQuery request, CancellationToken cancellationToken)
    {
        var courseFromDatabase = await _repository.GetCourseWithAuthorsByIdAsync(request.PublisherId,request.CourseId);
        return _mapper.Map<GetCourseWithAuthorsDetailDto>(courseFromDatabase);
    }
}