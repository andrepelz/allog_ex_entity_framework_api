using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Univali.Api.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommand : IRequest<CreateCustomerDto> {
    public Models.CustomerForCreationDto Dto { get; set; } = new Models.CustomerForCreationDto();
}