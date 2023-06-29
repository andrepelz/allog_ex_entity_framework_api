using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerDto> {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(ICustomerRepository repository, IMapper mapper) {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<UpdateCustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken) {
        bool success = false;

        var customerFromDatabase = await _repository.GetCustomerByIdAsync(request.Dto.CustomerId);

        if(customerFromDatabase != null) {
            _repository.UpdateCustomer(customerFromDatabase, request.Dto);
            await _repository.SaveChangesAsync();

            success = true;
        }

        return new UpdateCustomerDto { Success = success };
    }
}