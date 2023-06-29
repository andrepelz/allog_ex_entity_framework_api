using MediatR;

namespace Univali.Api.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<UpdateCustomerDto> {
    public Models.CustomerForUpdateDto Dto { get; set; } = new Models.CustomerForUpdateDto();
}