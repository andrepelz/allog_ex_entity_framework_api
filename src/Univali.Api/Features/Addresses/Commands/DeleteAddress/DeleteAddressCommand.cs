using MediatR;

namespace Univali.Api.Features.Addresses.Commands.DeleteAddress;

public class DeleteAddressCommand : IRequest<DeleteAddressDto> {
    public int CustomerId { get; set; }
    public int AddressId { get; set; }
}