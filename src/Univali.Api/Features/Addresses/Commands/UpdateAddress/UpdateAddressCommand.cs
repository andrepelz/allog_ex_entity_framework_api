using MediatR;

namespace Univali.Api.Features.Addresses.Commands.UpdateAddress;

public class UpdateAddressCommand : IRequest<UpdateAddressDto> {
    public int CustomerId { get; set; }
    public Models.AddressForUpdateDto Dto { get; set; } = new Models.AddressForUpdateDto();
}