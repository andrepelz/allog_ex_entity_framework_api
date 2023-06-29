namespace Univali.Api.Features.Customers.Queries.GetAllCustomersWithAddresses;

public class GetAllCustomersWithAddressesDto {
    public IEnumerable<Models.CustomerWithAddressesDto> Customers { get; set; } = new List<Models.CustomerWithAddressesDto>();
}