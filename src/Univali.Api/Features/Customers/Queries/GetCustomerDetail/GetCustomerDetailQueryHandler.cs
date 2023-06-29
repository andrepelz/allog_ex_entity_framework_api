using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Customers.Queries.GetCustomerDetail;

public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, GetCustomerDetailDto> {
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetCustomerDetailQueryHandler(ICustomerRepository repository, IMapper mapper) {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<GetCustomerDetailDto> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken) {
        var customerFromDatabase = await _repository.GetCustomerByIdAsync(request.Id);

        return _mapper.Map<GetCustomerDetailDto>(customerFromDatabase);
    }
}