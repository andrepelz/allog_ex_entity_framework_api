namespace Univali.Api.Features.Customers.Queries.GetAllCustomers;

public class GetAllCustomersDto {
    public IEnumerable<Models.CustomerDto> Customers { get; set; } = new List<Models.CustomerDto>();
}