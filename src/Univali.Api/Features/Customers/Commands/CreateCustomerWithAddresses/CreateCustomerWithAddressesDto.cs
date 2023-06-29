namespace Univali.Api.Features.Customers.Commands.CreateCustomerWithAddresses;

public class CreateCustomerWithAddressesDto {
    public int CustomerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public List<Models.AddressDto> Addresses { get; set; } = new List<Models.AddressDto>();
}