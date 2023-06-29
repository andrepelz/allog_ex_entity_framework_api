using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

using Univali.Api.Features.Addresses.Commands.CreateAddress;
using Univali.Api.Features.Addresses.Commands.DeleteAddress;
using Univali.Api.Features.Addresses.Commands.PatchAddress;
using Univali.Api.Features.Addresses.Commands.UpdateAddress;
using Univali.Api.Features.Addresses.Queries.GetAddressDetail;
using Univali.Api.Features.Addresses.Queries.GetAllAddresses;
using Univali.Api.Models;

namespace Univali.Api.Controllers;

[Route("api/customers/{customerId}/addresses")]
[Authorize]
public class AddressesControler : MainController {
    private readonly IMediator _mediator;

    public AddressesControler(IMediator mediator) {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }



    [HttpGet]
    public async Task<ActionResult <IEnumerable <AddressDto>>> GetAddresses(int customerId) {
        var getAllAddressesQuery = new GetAllAddressesQuery { CustomerId = customerId };
        var result = await _mediator.Send(getAllAddressesQuery);

        var addressesToReturn = result.Addresses;

        return addressesToReturn != null ? Ok(addressesToReturn) : NotFound();
    }

    [HttpGet("{addressId}", Name = "GetAddressById")]
    public async Task<ActionResult <GetAddressDetailDto>> GetAddressById(int customerId, int addressId) {
        var getAddressDetailQuery = new GetAddressDetailQuery { 
            CustomerId = customerId, 
            AddressId = addressId 
        };
        var addressToReturn = await _mediator.Send(getAddressDetailQuery);

        return addressToReturn != null ? Ok(addressToReturn) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult <CreateAddressDto>> CreateAddress (int customerId, AddressForCreationDto addressForCreationDto) {
        var createAddressCommand = new CreateAddressCommand { 
            CustomerId = customerId, 
            Dto = addressForCreationDto 
        };
        var addressToReturn = await _mediator.Send(createAddressCommand);

        return addressToReturn != null 
            ? CreatedAtRoute(
                "GetAddressById",
                new { 
                    customerId,
                    addressId = addressToReturn.AddressId 
                },
                addressToReturn
            )
            : NotFound();
    }

    [HttpPut("{addressId}")]
    public async Task<ActionResult> UpdateAddress (int customerId, int addressId, AddressForUpdateDto addressForUpdateDto) {
        if(addressForUpdateDto.AddressId != addressId) return BadRequest();

        var updateAddressCommand = new UpdateAddressCommand { 
            CustomerId = customerId, 
            Dto = addressForUpdateDto 
        };
        var result = await _mediator.Send(updateAddressCommand);

        return result.Success ? NoContent() : NotFound();
    }

    [HttpDelete("{addressId}")]
    public async Task<ActionResult> DeleteAddress(int customerId, int addressId) {
        var deleteAddressCommand = new DeleteAddressCommand { 
            CustomerId = customerId, 
            AddressId = addressId 
        };
        var result = await _mediator.Send(deleteAddressCommand);

        return result.Success ? NoContent() : NotFound();
    }

    [HttpPatch("{addressId}")]
    public async Task<ActionResult> PartiallyUpdateAddress(
        [FromBody] JsonPatchDocument<AddressForPatchDto> patchDocument, 
        [FromRoute] int customerId,
        [FromRoute] int addressId
    ) {
        var patchAddressCommand = new PatchAddressCommand { 
            CustomerId = customerId,
            AddressId = addressId,
            PatchDocument = patchDocument
        };
        var result = await _mediator.Send(patchAddressCommand);

        return result.Success ? NoContent() : NotFound();
    }
}
