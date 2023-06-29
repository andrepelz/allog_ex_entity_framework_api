using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Univali.Api.Features.Customers.Commands.PatchCustomer;

public class PatchCustomerCommand : IRequest<PatchCustomerDto> {
    public int Id { get; set; }
    public JsonPatchDocument<Models.CustomerForPatchDto> PatchDocument { get; set; } = new JsonPatchDocument<Models.CustomerForPatchDto>();
}