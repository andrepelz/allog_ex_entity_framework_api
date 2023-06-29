using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Addresses.Commands.DeleteAddress;

public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, DeleteAddressDto> {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public DeleteAddressCommandHandler(ICustomerRepository repository, IMapper mapper) 
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<DeleteAddressDto> Handle(DeleteAddressCommand request, CancellationToken cancellationToken) 
    {
        bool success = false;
        
        var addressFromDatabase = await _repository.GetAddressByIdAsync(request.CustomerId, request.AddressId);

        if(addressFromDatabase != null) {
            _repository.RemoveAddress(addressFromDatabase);
            await _repository.SaveChangesAsync();

            success = true;
        }

        return new DeleteAddressDto { Success = success };
    }
}
