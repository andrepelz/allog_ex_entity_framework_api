using MediatR;

namespace Univali.Api.Features.Customers.Queries.GetCustomerWithAddresses;

public class GetCUstomerWithAddressesQuery : IRequest<GetCustomerWithAddressesDto> {
    public int Id { get; set; }
}