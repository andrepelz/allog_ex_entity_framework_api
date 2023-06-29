using Univali.Api.Models;

namespace Univali.Api.Features.Addresses.Queries.GetAllAddresses;

public class GetAllAddressesDto {
    public List<AddressDto> Addresses { get; set; } = new();
}