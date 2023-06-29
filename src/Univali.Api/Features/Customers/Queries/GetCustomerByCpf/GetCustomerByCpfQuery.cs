using MediatR;

namespace Univali.Api.Features.Customers.Queries.GetCustomerByCpf;

public class GetCustomerByCpfQuery : IRequest<GetCustomerByCpfDto> {
    public string Cpf { get; set; } = string.Empty;
}