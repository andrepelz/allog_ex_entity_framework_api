using MediatR;

namespace Univali.Api.Features.Addresses.Queries.GetAllAddresses;

public class GetAllAddressesQuery : IRequest<GetAllAddressesDto> {
    public int CustomerId { get; set; }
}