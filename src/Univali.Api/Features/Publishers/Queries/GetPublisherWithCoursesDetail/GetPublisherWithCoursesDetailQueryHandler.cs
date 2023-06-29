using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Publishers.Queries.GetPublisherWithCoursesDetail;

public class GetPublisherWithCoursesDetailQueryHandler : IRequestHandler<GetPublisherWithCoursesDetailQuery, GetPublisherWithCoursesDetailDto>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public GetPublisherWithCoursesDetailQueryHandler(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetPublisherWithCoursesDetailDto> Handle(GetPublisherWithCoursesDetailQuery request, CancellationToken cancellationToken)
    {
        var publisherFromDatabase = await _repository.GetPublisherWithCoursesByIdAsync(request.PublisherId);
        return _mapper.Map<GetPublisherWithCoursesDetailDto>(publisherFromDatabase);
    }
}