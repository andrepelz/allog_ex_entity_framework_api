using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Publishers.Queries.GetPublisherDetail;

public class GetPublisherDetailQueryHandler : IRequestHandler<GetPublisherDetailQuery, GetPublisherDetailDto>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public GetPublisherDetailQueryHandler(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetPublisherDetailDto> Handle(GetPublisherDetailQuery request, CancellationToken cancellationToken)
    {
        var publisherFromDatabase = await _repository.GetPublisherByIdAsync(request.PublisherId);
        return _mapper.Map<GetPublisherDetailDto>(publisherFromDatabase);
    }
}