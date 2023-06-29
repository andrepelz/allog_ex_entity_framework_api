using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Univali.Api.Features.Addresses.Commands.PatchAddress;

public class PatchAddressCommand : IRequest<PatchAddressDto> {
    public int CustomerId { get; set; }
    public int AddressId { get; set; }
    public JsonPatchDocument<Models.AddressForPatchDto> PatchDocument { get; set; } = new JsonPatchDocument<Models.AddressForPatchDto>();
}