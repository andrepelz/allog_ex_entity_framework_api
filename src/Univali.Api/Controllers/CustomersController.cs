using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.Features.Customers.Commands.CreateCustomer;
using Univali.Api.Features.Customers.Commands.CreateCustomerWithAddresses;
using Univali.Api.Features.Customers.Commands.DeleteCustomer;
using Univali.Api.Features.Customers.Commands.PatchCustomer;
using Univali.Api.Features.Customers.Commands.UpdateCustomer;
using Univali.Api.Features.Customers.Queries.GetAllCustomers;
using Univali.Api.Features.Customers.Queries.GetAllCustomersWithAddresses;
using Univali.Api.Features.Customers.Queries.GetCustomerByCpf;
using Univali.Api.Features.Customers.Queries.GetCustomerDetail;
using Univali.Api.Features.Customers.Queries.GetCustomerWithAddresses;
using Univali.Api.Models;

namespace Univali.Api.Controllers;

[Route("api/customers")]
[Authorize]
public class CustomersController : MainController {
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator) {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }



    [HttpGet]
    public async Task<ActionResult <IEnumerable <CustomerDto>>> GetCustomers() {
        var getAllCustomersQuery = new GetAllCustomersQuery();
        var result = await _mediator.Send(getAllCustomersQuery);

        var customersToReturn = result.Customers;

        return Ok(customersToReturn);
    }

    [HttpGet("with-addresses", Name = "GetCustomersWithAddresses")]
    public async Task<ActionResult <IEnumerable <CustomerDto>>> GetCustomersWithAddresses() {
        var getAllCustomersQuery = new GetAllCustomersWithAddressesQuery();
        var result = await _mediator.Send(getAllCustomersQuery);

        var customersToReturn = result.Customers;

        return Ok(customersToReturn);
    }

    [HttpGet("{customerId}", Name = "GetCustomerById")]
    public async Task<ActionResult <GetCustomerDetailDto>> GetCustomerById(int customerId) {
        var getCustomerDetailQuery = new GetCustomerDetailQuery { Id = customerId };
        var customerToReturn = await _mediator.Send(getCustomerDetailQuery);

        return customerToReturn != null ? Ok(customerToReturn) : NotFound();
    }

    [HttpGet("with-addresses/{customerId}", Name = "GetCustomerWithAddressesById")]
    public async Task<ActionResult <GetCustomerWithAddressesDto>> GetCustomerWithAddressesById(int customerId) {
        var getCustomerWithAddressesQuery = new GetCUstomerWithAddressesQuery { Id = customerId };
        var customerToReturn = await _mediator.Send(getCustomerWithAddressesQuery);

        return customerToReturn != null ? Ok(customerToReturn) : NotFound();
    }

    [HttpGet("cpf/{cpf}")]
    public async Task<ActionResult <GetCustomerByCpfDto>> GetCustomerByCpf(string cpf) {
        var getCustomerByCpfQuery = new GetCustomerByCpfQuery { Cpf = cpf };
        var customerToReturn = await _mediator.Send(getCustomerByCpfQuery);

        return customerToReturn != null ? Ok(customerToReturn) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult <CreateCustomerDto>> CreateCustomer(CustomerForCreationDto customerForCreationDto) {
        var createCustomerCommand = new CreateCustomerCommand { Dto = customerForCreationDto };
        var customerToReturn = await _mediator.Send(createCustomerCommand);

        return CreatedAtRoute(
            "GetCustomerById",
            new { customerId = customerToReturn.CustomerId },
            customerToReturn
        );
    }

    [HttpPost("with-addresses")]
    public async Task<ActionResult <CreateCustomerWithAddressesDto>> CreateCustomerWithAddresses(
        CustomerWithAddressesForCreationDto customerForCreationDto
    ) {
        var createCustomerCommand = new CreateCustomerWithAddressesCommand { Dto = customerForCreationDto };
        var customerToReturn = await _mediator.Send(createCustomerCommand);

        return CreatedAtRoute(
            "GetCustomerWithAddressesById",
            new { customerId = customerToReturn.CustomerId },
            customerToReturn
        );
    }

    [HttpPut("{customerId}")]
    public async Task<ActionResult> UpdateCustomer(int customerId, CustomerForUpdateDto customerForUpdateDto) {
        if(customerForUpdateDto.CustomerId != customerId) return BadRequest();

        var updateCustomerCommand = new UpdateCustomerCommand { Dto = customerForUpdateDto };
        var result = await _mediator.Send(updateCustomerCommand);

        return result.Success ? NoContent() : NotFound();
    }

    [HttpDelete("{customerId}")]
    public async Task<ActionResult> DeleteCustomer(int customerId) {
        var deleteCustomerCommand = new DeleteCustomerCommand { Id = customerId };
        var result = await _mediator.Send(deleteCustomerCommand);

        return result.Success ? NoContent() : NotFound();
    }

    [HttpPatch("{customerId}")]
    public async Task<ActionResult> PartiallyUpdateCustomer(
        [FromBody] JsonPatchDocument<CustomerForPatchDto> patchDocument, 
        [FromRoute] int customerId
    ) {
        var patchCustomerCommand = new PatchCustomerCommand { 
            Id = customerId,
            PatchDocument = patchDocument
        };
        var result = await _mediator.Send(patchCustomerCommand);

        return result.Success ? NoContent() : NotFound();
    }
}
