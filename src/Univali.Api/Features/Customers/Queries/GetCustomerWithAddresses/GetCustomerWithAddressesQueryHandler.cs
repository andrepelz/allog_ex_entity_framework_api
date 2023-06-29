using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Customers.Queries.GetCustomerWithAddresses;

public class GetCustomerWithAddressesQueryHandler : IRequestHandler<GetCUstomerWithAddressesQuery, GetCustomerWithAddressesDto> {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetCustomerWithAddressesQueryHandler(ICustomerRepository repository, IMapper mapper) {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<GetCustomerWithAddressesDto> Handle(GetCUstomerWithAddressesQuery request, CancellationToken cancellationToken) {
        var customerFromDatabase = await _repository.GetCustomerWithAddressesByIdAsync(request.Id);

        return _mapper.Map<GetCustomerWithAddressesDto>(customerFromDatabase);
    }
}