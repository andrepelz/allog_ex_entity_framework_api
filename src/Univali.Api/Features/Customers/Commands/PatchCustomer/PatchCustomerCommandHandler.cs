using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Customers.Commands.PatchCustomer;

public class PatchCustomerCommandHandler : IRequestHandler<PatchCustomerCommand, PatchCustomerDto> {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public PatchCustomerCommandHandler(ICustomerRepository repository, IMapper mapper) {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<PatchCustomerDto> Handle(PatchCustomerCommand request, CancellationToken cancellationToken) {
        bool success = false;

        var customerFromDatabase = await _repository.GetCustomerByIdAsync(request.Id);

        if (customerFromDatabase != null) {
            var customerToPatch = _mapper.Map<Models.CustomerForPatchDto>(customerFromDatabase);

            request.PatchDocument.ApplyTo(customerToPatch);

            _repository.PatchCustomer(customerFromDatabase, customerToPatch);
            await _repository.SaveChangesAsync();

            success = true;
        }

        return new PatchCustomerDto { Success = success };
    }
}
