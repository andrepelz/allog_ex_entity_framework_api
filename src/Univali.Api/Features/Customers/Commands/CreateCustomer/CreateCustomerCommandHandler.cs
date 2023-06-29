using AutoMapper;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerDto> {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(ICustomerRepository repository, IMapper mapper) {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<CreateCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken) {
        var newCustomer = _mapper.Map<Customer>(request.Dto);

        _repository.AddCustomer(newCustomer);
        await _repository.SaveChangesAsync();

        var customerToReturn = _mapper.Map<CreateCustomerDto>(newCustomer);
        
        return customerToReturn;
    }
}