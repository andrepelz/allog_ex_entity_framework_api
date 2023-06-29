using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Authors.Queries.GetAuthorDetail;

public class GetAuthorDetailQueryHandler : IRequestHandler<GetAuthorDetailQuery, GetAuthorDetailDto>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public GetAuthorDetailQueryHandler(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetAuthorDetailDto> Handle(GetAuthorDetailQuery request, CancellationToken cancellationToken)
    {
        var authorFromDatabase = await _repository.GetAuthorByIdAsync(request.Id);
        return _mapper.Map<GetAuthorDetailDto>(authorFromDatabase);
    }
}