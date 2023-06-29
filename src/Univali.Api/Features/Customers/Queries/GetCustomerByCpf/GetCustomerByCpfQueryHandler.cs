using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Customers.Queries.GetCustomerByCpf;

public class GetCustomerByCpfQueryHandler : IRequestHandler<GetCustomerByCpfQuery, GetCustomerByCpfDto> {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetCustomerByCpfQueryHandler(ICustomerRepository repository, IMapper mapper) {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<GetCustomerByCpfDto> Handle(GetCustomerByCpfQuery request, CancellationToken cancellationToken) {
        var customerFromDatabase = await _repository.GetCustomerByCpfAsync(request.Cpf);

        return _mapper.Map<GetCustomerByCpfDto>(customerFromDatabase);
    }
}