using AutoMapper;
using MediatR;
using Univali.Api.Models;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Addresses.Queries.GetAllAddresses;

public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, GetAllAddressesDto>
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetAllAddressesQueryHandler(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetAllAddressesDto> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
    {
        List<AddressDto> addressesToReturn = null!;
        var addressesFromDatabase = await _repository.GetAddressesAsync(request.CustomerId);

        if(addressesFromDatabase != null)
            addressesToReturn = _mapper.Map<IEnumerable<AddressDto> >(addressesFromDatabase).ToList();

        return new GetAllAddressesDto { Addresses = addressesToReturn };
    }
}