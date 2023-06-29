using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerDto> {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public DeleteCustomerCommandHandler(ICustomerRepository repository, IMapper mapper) {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<DeleteCustomerDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken) {
        bool success = false;

        var customerFromDatabase = await _repository.GetCustomerByIdAsync(request.Id);

        if(customerFromDatabase != null) {
            _repository.RemoveCustomer(customerFromDatabase);
            await _repository.SaveChangesAsync();

            success = true;
        }

        return new DeleteCustomerDto { Success = success };
    }
}
