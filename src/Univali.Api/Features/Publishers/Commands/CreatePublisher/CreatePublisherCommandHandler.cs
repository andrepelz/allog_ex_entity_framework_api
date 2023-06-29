using AutoMapper;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Publishers.CreatePublisher;

public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommand, CreatePublisherDto>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public CreatePublisherCommandHandler(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CreatePublisherDto> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
    {
        var newPublisher = _mapper.Map<Publisher>(request.Dto);

        _repository.AddPublisher(newPublisher);
        await _repository.SaveChangesAsync();

        var publisherToReturn = _mapper.Map<CreatePublisherDto>(newPublisher);
        
        return publisherToReturn;
    }
}	