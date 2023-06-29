namespace Univali.Api.Features.Addresses.Commands.CreateAddress;

public class CreateAddressDto{
    public int AddressId { get; set; }
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}