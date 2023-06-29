using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Customers.Queries.GetAllCustomersWithAddresses;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersWithAddressesQuery, GetAllCustomersWithAddressesDto> {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCustomersQueryHandler(ICustomerRepository repository, IMapper mapper) {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<GetAllCustomersWithAddressesDto> Handle(GetAllCustomersWithAddressesQuery request, CancellationToken cancellationToken) {
        var customers = await _repository.GetCustomersWithAddressesAsync();

        var customersToReturn = _mapper.Map<IEnumerable <Models.CustomerWithAddressesDto>>(customers);

        return new GetAllCustomersWithAddressesDto { Customers = customersToReturn };
    }
}