using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Authors.Queries.GetAuthorWithCoursesDetail;

public class GetAuthorWithCoursesDetailQueryHandler : IRequestHandler<GetAuthorWithCoursesDetailQuery, GetAuthorWithCoursesDetailDto>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public GetAuthorWithCoursesDetailQueryHandler(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetAuthorWithCoursesDetailDto> Handle(GetAuthorWithCoursesDetailQuery request, CancellationToken cancellationToken)
    {
        var authorFromDatabase = await _repository.GetAuthorWithCoursesByIdAsync(request.Id);
        return _mapper.Map<GetAuthorWithCoursesDetailDto>(authorFromDatabase);
    }
}