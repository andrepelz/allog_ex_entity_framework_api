using MediatR;

namespace Univali.Api.Features.Addresses.Queries.GetAddressDetail;

public class GetAddressDetailQuery : IRequest<GetAddressDetailDto> {
    public int CustomerId { get; set; }
    public int AddressId { get; set; }
}