using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Addresses.Queries.GetAddressDetail;

public class GetAddressDetailQueryHandler : IRequestHandler<GetAddressDetailQuery, GetAddressDetailDto>
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetAddressDetailQueryHandler(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetAddressDetailDto> Handle(GetAddressDetailQuery request, CancellationToken cancellationToken)
    {
        var addressFromDatabase = await _repository.GetAddressByIdAsync(request.CustomerId, request.AddressId);
        return _mapper.Map<GetAddressDetailDto>(addressFromDatabase);
    }
}