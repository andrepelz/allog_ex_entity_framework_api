using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Univali.Api.Features.Addresses.Commands.CreateAddress;

public class CreateAddressCommand : IRequest<CreateAddressDto> {
    public int CustomerId { get; set; }
    public Models.AddressForCreationDto Dto { get; set; } = new Models.AddressForCreationDto();
}