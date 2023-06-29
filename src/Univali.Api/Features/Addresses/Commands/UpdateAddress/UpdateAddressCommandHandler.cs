using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Addresses.Commands.UpdateAddress;

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdateAddressDto> {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public UpdateAddressCommandHandler(ICustomerRepository repository, IMapper mapper) 
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<UpdateAddressDto> Handle(UpdateAddressCommand request, CancellationToken cancellationToken) 
    {
        bool success = false;

        var addressFromDatabase = await _repository.GetAddressByIdAsync(request.CustomerId, request.Dto.AddressId);

        if(addressFromDatabase != null) {
            _repository.UpdateAddress(addressFromDatabase, request.Dto);
            await _repository.SaveChangesAsync();

            success = true;
        }
        
        return new UpdateAddressDto { Success = success };
    }
}