using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Publishers.Commands.DeletePublisher;

public class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommand, DeletePublisherDto>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public DeletePublisherCommandHandler(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<DeletePublisherDto> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
    {
        bool success = false;

        var publisherFromDatabase = await _repository.GetPublisherByIdAsync(request.PublisherId);

        if (publisherFromDatabase != null) {
            _repository.RemovePublisher(publisherFromDatabase);
            await _repository.SaveChangesAsync();

            success = true;
        }

        return new DeletePublisherDto { Success = success };
    }
}