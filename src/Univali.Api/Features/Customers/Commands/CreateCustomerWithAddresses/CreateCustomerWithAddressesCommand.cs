using MediatR;

namespace Univali.Api.Features.Customers.Commands.CreateCustomerWithAddresses;

public class CreateCustomerWithAddressesCommand : IRequest<CreateCustomerWithAddressesDto> {
    public Models.CustomerWithAddressesForCreationDto Dto { get; set; } = new Models.CustomerWithAddressesForCreationDto();
}