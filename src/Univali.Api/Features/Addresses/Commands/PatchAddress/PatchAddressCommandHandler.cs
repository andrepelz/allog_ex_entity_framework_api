using AutoMapper;
using MediatR;
using Univali.Api.Models;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Addresses.Commands.PatchAddress;

public class PatchAddressCommandHandler : IRequestHandler<PatchAddressCommand, PatchAddressDto> {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public PatchAddressCommandHandler(ICustomerRepository repository, IMapper mapper) 
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<PatchAddressDto> Handle(PatchAddressCommand request, CancellationToken cancellationToken) 
    {
        bool success = false;

        var addressFromDatabase = await _repository.GetAddressByIdAsync(request.CustomerId, request.AddressId);

        if (addressFromDatabase != null) {
            var addressToPatch = _mapper.Map<AddressForPatchDto>(addressFromDatabase);

            request.PatchDocument.ApplyTo(addressToPatch);

            _repository.PatchAddress(addressFromDatabase, addressToPatch);
            await _repository.SaveChangesAsync();

            success = true;
        }

        return new PatchAddressDto { Success = success };
    }
}
