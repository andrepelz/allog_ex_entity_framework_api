using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Customers.Queries.GetAllCustomers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, GetAllCustomersDto> {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCustomersQueryHandler(ICustomerRepository repository, IMapper mapper) {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<GetAllCustomersDto> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken) {
        var customers = await _repository.GetCustomersAsync();

        var customersToReturn = _mapper.Map<IEnumerable <Models.CustomerDto>>(customers);

        return new GetAllCustomersDto { Customers = customersToReturn };
    }
}