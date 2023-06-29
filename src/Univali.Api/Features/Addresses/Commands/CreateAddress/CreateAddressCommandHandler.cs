using AutoMapper;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Addresses.Commands.CreateAddress;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreateAddressDto> {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public CreateAddressCommandHandler(ICustomerRepository repository, IMapper mapper) 
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<CreateAddressDto> Handle(CreateAddressCommand request, CancellationToken cancellationToken) 
    {
        CreateAddressDto addressToReturn = null!;
        var customerFromDatabase = await _repository.GetCustomerByIdAsync(request.CustomerId);

        if(customerFromDatabase != null) {
            var newAddress = _mapper.Map<Address>(request.Dto);

            _repository.AddAddress(customerFromDatabase, newAddress);
            await _repository.SaveChangesAsync();
            
            addressToReturn = _mapper.Map<CreateAddressDto>(newAddress);
        }
        
        return addressToReturn;
    }
}